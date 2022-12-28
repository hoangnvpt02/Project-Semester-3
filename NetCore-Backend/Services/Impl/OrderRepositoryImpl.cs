﻿using NetCore_Backend.Models;
using NetCore_Backend.Data;
using Microsoft.CodeAnalysis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace NetCore_Backend.Services.Impl
{
    public class OrderRepositoryImpl : IOrderRepository
    {
        private readonly MyDbContext _context;
        public OrderRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public OrderModel Add(OrderModel orderModel)
        {
            var order = new Order();
            order.UserId = orderModel.UserId;
            order.ProductId = orderModel.ProductId;
            order.Status = orderModel.Status;
            order.Price = orderModel.Price;
            order.IsActive = orderModel.IsActive;
            order.Created = orderModel.Created;
            order.Updated = orderModel.Updated;
            _context.Add(order);
            _context.SaveChanges();
            return new OrderModel()
            {
                Id = order.Id,
                ProductId = order.ProductId,
                UserId = order.UserId,
                Price = order.Price,
                Status = order.Status,
                IsActive = order.IsActive,
                Created = order.Created,
                Updated = order.Updated,
            };
        }

        public void Delete(long id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if(order != null)
            {
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public Array GetAll()
        {

            var orders = _context.Orders
            .Join(_context.Products, order => order.ProductId, product => product.Id, (order, product) => new { order,product })
            .Select(o => new
             {
                Id = o.order.Id,
                Price = o.order.Price,
                Status = o.order.Status,
                IsActive = o.order.IsActive,
                Name = o.product.Name,
                FileDetailsId = o.product.FileDetailsId,
            }) 
            .ToList()
            .ToArray();

            return orders;
        }

        public OrderModel GetById(long id)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if(order != null)
            {
                return new OrderModel()
                {
                    Id = order.Id,
                    ProductId = order.ProductId,
                    UserId = order.UserId,
                    Price = order.Price,
                    Status = order.Status,
                    IsActive = order.IsActive,
                    Created = order.Created,
                    Updated = order.Updated,
                };
            }
            return null;
        }

        public void Update(OrderModel orderModel)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderModel.Id);
            if(order != null)
            {
                order.Status = orderModel.Status;
                order.IsActive = orderModel.IsActive;
                order.Updated = orderModel.Updated;
                order.UserId = orderModel.UserId;
                order.Price = orderModel.Price;
                order.ProductId = orderModel.ProductId;
                _context.Update(order);
                _context.SaveChanges();
            }
        }

        public int GetQuantityOrder()
        {
            var total = _context.Orders.ToList().Count;
            return total;
        }
    }
}

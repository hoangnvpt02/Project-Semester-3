using NetCore_Backend.Models;
using NetCore_Backend.Data;
using Microsoft.CodeAnalysis;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;
using System.Net;
using Microsoft.IdentityModel.Tokens;

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
            var product = _context.Products.FirstOrDefault(p => p.Id == orderModel.ProductId);

            var order = new Order();
            order.AspNetUsersId = orderModel.AspNetUsersId;
            order.ProductId = orderModel.ProductId;
            order.Status = orderModel.Status;

            if (product != null)
            {
                if (product.SalePercent > 0)
                {
                    order.Price = (decimal)product.PriceSale;
                }
                if (product.PriceAuction > 0)
                {
                    order.Price = (decimal)product.PriceAuction;
                }
                else
                {
                    order.Price = product.Price;
                }
            }

            order.IsActive = orderModel.IsActive;
            order.Created = orderModel.Created;
            order.Updated = orderModel.Updated;
            _context.Add(order);
            _context.SaveChanges();
            return new OrderModel()
            {
                Id = order.Id,
                ProductId = order.ProductId,
                AspNetUsersId = order.AspNetUsersId,
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
                order.IsActive = 1;
                _context.SaveChanges();
            }
        }

        public Array GetAll(string userId, int status)
        {

            var orders = _context.Orders
            .Where(order => order.IsActive == 0)
            .Join(_context.Products, order => order.ProductId, product => product.Id, (order, product) => new { order, product })
            .Join(_context.Users, o => o.order.AspNetUsersId, user => user.Id, (order1, user) => new { order1, user })
            .Select(o => new
            {
                Id = o.order1.order.Id,
                TotalPrice = o.order1.order.Price,
                Status = o.order1.order.Status,
                IsActive = o.order1.order.IsActive,
                UserName = o.user.UserName,
                Name = o.order1.product.Name,
                PriceProduct = o.order1.product.Price,
                FileDetailsId = o.order1.product.FileDetailsId,
                FullName = o.user.UserName,
                Email = o.user.Email,
                Phone = o.user.PhoneNumber,
                Address = o.user.Address,
                AspNetUsersId = o.order1.order.AspNetUsersId,
            });

            if (status == 0)
            {
                orders = orders.Where(order => order.Status == status);
            } else
            {
                orders = orders.Where(order => order.Status > 0);
            }

            if (userId != "Admin")
            {
                orders = orders.Where(order => order.AspNetUsersId == userId);
            }

            return orders.ToList().ToArray();
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
                    AspNetUsersId = order.AspNetUsersId,
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
            var order = _context.Orders
            .FirstOrDefault(o => o.Id == orderModel.Id);
            if(order != null)
            {
                order.Status = orderModel.Status;
                order.IsActive = orderModel.IsActive;
                order.Updated = orderModel.Updated;
                order.AspNetUsersId = orderModel.AspNetUsersId;
                order.Price = orderModel.Price;
                order.ProductId = orderModel.ProductId;
                _context.Update(order);
                _context.SaveChanges();
            }
        }

        public int GetQuantityOrder(string userId)
        {
            var total = _context.Orders
                .Where(order => order.AspNetUsersId == userId)
                .Where(order => order.Status == 0)
                .Where(order => order.IsActive == 0)
                .ToList().Count;
            return total;
        }

        public void UpdateStatus(long id, int status, string email, string address)
        {
            var order = _context.Orders.FirstOrDefault(o => o.Id == id);
            if (order != null)
            {
                order.Status = status;
                _context.Update(order);
                _context.SaveChanges();
            }

            var user = _context.Users.Where(u => u.Email == email).FirstOrDefault();
            if (user != null && email != "Empty" && address != "Empty")
            {
                user.Address = address;
                _context.Update(user);
                _context.SaveChanges();
            }
        }
    }
}

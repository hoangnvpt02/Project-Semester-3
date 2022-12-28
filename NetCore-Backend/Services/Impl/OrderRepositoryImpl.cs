using NetCore_Backend.Models;
using NetCore_Backend.Data;

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
            order.AspNetUsersId = orderModel.AspNetUsersId;
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
                _context.Orders.Remove(order);
                _context.SaveChanges();
            }
        }

        public List<OrderModel> GetAll()
        {
            var orders = _context.Orders.Select(o => new OrderModel()
            {
                Id = o.Id,
                ProductId = o.ProductId,
                AspNetUsersId = o.AspNetUsersId,
                Price = o.Price,
                Status = o.Status,
                IsActive = o.IsActive,
                Created = o.Created,
                Updated = o.Updated,
            });
            return orders.ToList();
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
            var order = _context.Orders.FirstOrDefault(o => o.Id == orderModel.Id);
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
    }
}

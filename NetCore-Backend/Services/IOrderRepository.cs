using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IOrderRepository
    {
        List<OrderModel> GetAll();
        OrderModel GetById(long id);
        OrderModel Add(OrderModel orderModel);
        void Update(OrderModel orderModel);
        void Delete(long id);
    }
}

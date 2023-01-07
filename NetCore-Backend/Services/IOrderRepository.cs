using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IOrderRepository
    {
        Array GetAll(string userId, int status);
        OrderModel GetById(long id);
        OrderModel Add(OrderModel orderModel);
        void Update(OrderModel orderModel);
        void Delete(long id);
        int GetQuantityOrder(string userId);

        void UpdateStatus(long id, int status, string email, string address);
    }
}

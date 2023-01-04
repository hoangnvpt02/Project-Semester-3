using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IUserRepository
    {
        List<UserModel> GetAll();
        UserModel GetById(string id);
        UserModel Add(UserModel user);
        void Update(UserModel user);
        void Delete(string id);
    }
}

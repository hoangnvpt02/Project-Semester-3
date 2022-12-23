using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IUserRoleRepository
    {
        List<UserRoleModel> GetAll();
        UserRoleModel GetById(long id);
        UserRoleModel Add(UserRoleModel userRole);
        void Update(UserRoleModel userRole);
        void Delete(long id);
    }
}

using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface IRoleRepository
    {
        List<RoleModel> GetAll();
        RoleModel GetById(long id);
        RoleModel Add(RoleModel role);
        void Update(RoleModel role);
        void Delete(long id);
    }
}

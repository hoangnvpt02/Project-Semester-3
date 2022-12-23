using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class UserRoleRepositoryImpl : IUserRoleRepository
    {
        private readonly MyDbContext _context;

        public UserRoleRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }
        public List<UserRoleModel> GetAll()
        {
            var result = _context.UserRoles.Select(x => new UserRoleModel()
            {
                id = x.id,
                UserId = x.UserId,
                RoleId = x.RoleId,
                IsActive = x.IsActive,
                Created = x.Created,
                Updated = x.Updated,
            });
            return result.ToList();
        }

        public UserRoleModel GetById(long id)
        {
            var x = _context.UserRoles.FirstOrDefault(x => x.id == id);
            return new UserRoleModel()
            {
                id = x.id,
                UserId = x.UserId,
                RoleId = x.RoleId,
                IsActive = x.IsActive,
                Created = x.Created,
                Updated = x.Updated,
            };
        }

        public UserRoleModel Add(UserRoleModel userRole)
        {
            var _userRole = new UserRole();
           
            _userRole.UserId = userRole.UserId;
            _userRole.RoleId = userRole.RoleId;
            _userRole.IsActive = userRole.IsActive;
            _userRole.Created = userRole.Created;
            _userRole.Updated = userRole.Updated;
            _context.UserRoles.Add(_userRole);
            _context.SaveChanges();
            return new UserRoleModel()
            {
                id = _userRole.id,
                UserId = _userRole.UserId,
                RoleId = _userRole.RoleId,
                IsActive = _userRole.IsActive,
                Created = _userRole.Created,
                Updated = _userRole.Updated,
            };
        }

        public void Update(UserRoleModel userRole)
        {
            var _userRole = _context.UserRoles.FirstOrDefault(x => x.id == userRole.id);
            if (_userRole != null)
            {
                _userRole.UserId = userRole.UserId;
                _userRole.RoleId = userRole.RoleId;
                _userRole.IsActive = userRole.IsActive;
                _userRole.Created = userRole.Created;
                _userRole.Updated = userRole.Updated;
                _context.Update(_userRole);
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
           var userRole = _context.UserRoles.FirstOrDefault(x => x.id == id);
           if (userRole != null)
           {
               _context.UserRoles.Remove(userRole);
               _context.SaveChanges();
           }
        }
    }
}

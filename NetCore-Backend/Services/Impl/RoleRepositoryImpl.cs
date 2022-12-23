using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class RoleRepositoryImpl : IRoleRepository
    {
        private readonly MyDbContext _context;

        public RoleRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }
        public List<RoleModel> GetAll()
        {
            var roleList = _context.Roles.Select(r => new RoleModel()
            {
                Id = r.Id,
                Name = r.Name,
                Description = r.Description,
                IsActive = r.IsActive,
                Created = r.Created,
                Updated = r.Updated,
            });
            return roleList.ToList();
        }

        public RoleModel GetById(long id)
        {
            var r = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (r != null)
            {
                return new RoleModel()
                {
                    Id = r.Id,
                    Name = r.Name,
                    Description = r.Description,
                    IsActive = r.IsActive,
                    Created = r.Created,
                    Updated = r.Updated,
                };
            }

            return null;
        }

        public RoleModel Add(RoleModel role)
        {
            var u = new Role()
            {
                Id = role.Id,
                Name = role.Name,
                Description = role.Description,
                IsActive = role.IsActive,
                Created = role.Created,
                Updated = role.Updated,
            };
            _context.Roles.Add(u);
            _context.SaveChanges();
            return new RoleModel()
            {
                Id = u.Id,
                Name = u.Name,
                Description = u.Description,
                IsActive = u.IsActive,
                Created = u.Created,
                Updated = u.Updated,
            };

        }

        public void Update(RoleModel role)
        {
            var _role = _context.Roles.FirstOrDefault(r => r.Id == role.Id);
            if (_role != null)
            {
                _role.Name = role.Name;
                _role.Description = role.Description;
                _role.IsActive = role.IsActive;
                _role.Updated = role.Updated;
                _context.Update(_role);
                _context.SaveChanges();
            }
        }

        public void Delete(long id)
        {
            var role = _context.Roles.FirstOrDefault(r => r.Id == id);
            if (role != null)
            {
                _context.Remove(role);
                _context.SaveChanges();
            }
        }
    }
}

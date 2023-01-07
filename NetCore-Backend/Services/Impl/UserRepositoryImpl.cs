using NetCore_Backend.Models;
using NetCore_Backend.Data;
using System.Net;

namespace NetCore_Backend.Services.Impl
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public void Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if(user != null)
            {
                user.IsActive = 1;
                _context.SaveChanges();
            }
        }

        public List<UserModel> GetAll()
        {
            var users = _context.Users.Where(p => p.IsActive == 0).Select(u => new UserModel()
            {
                Id = u.Id,
                Name = u.Name,
                UserName = u.UserName,
                Email = u.Email,
                Phone = u.PhoneNumber,
                Address = u.Address,
                IsActive = u.IsActive
            });
            return users.ToList();
        }

        public UserModel GetById(string id)
        {
            var user = _context.Users.FirstOrDefault(u => u.Id == id);
            if(user != null)
            {
                return new UserModel()
                {
                    Id = user.Id,
                    Name = user.Name,
                    UserName = user.UserName,
                    Email = user.Email,
                    Phone = user.PhoneNumber,
                    Address = user.Address,
                    IsActive = user.IsActive
                };
            }
            return null;
        }

        public void Update(UserModel UserModel)
        {
            var users = _context.Users.FirstOrDefault(w => w.Id == UserModel.Id);
            if(users != null)
            {
                _context.Update(users);
                _context.SaveChanges();
            }
        }
    }
}

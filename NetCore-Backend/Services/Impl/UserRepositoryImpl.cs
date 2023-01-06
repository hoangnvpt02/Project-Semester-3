using NetCore_Backend.Models;
using NetCore_Backend.Data;
using Microsoft.AspNetCore.Identity;

namespace NetCore_Backend.Services.Impl
{
    public class UserRepositoryImpl : IUserRepository
    {
        private readonly MyDbContext _context;
        public UserRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public List<UserModel> GetAll()
        {
            var userList = _context.Users.Select(u => new UserModel()
            {
                Id = u.Id,

            });
            return userList.ToList();

        }

        public UserModel GetById(string id)
        {
            var u = _context.Users.FirstOrDefault(u => u.Id == id);
            if (u != null)
            {
                return new UserModel()
                {
                    Id = u.Id,
                };
            }

            return null;
        }

        public UserModel Add(UserModel user)
        {
            var _user = new IdentityUser()
            {
                Id = user.Id
            };
            _context.Add(_user);
            _context.SaveChanges();
            return new UserModel()
            {
                Id = user.Id,
                Password = user.Password,
                Name = user.Name,
                Email = user.Email,
                IsActive = user.IsActive,
                Phone = user.Phone,
                Address = user.Address,
                CreateDate = user.CreateDate,
                UpdateDate = user.UpdateDate,
            };
        }

        public void Update(UserModel user)
        {
            var _user = _context.Users.FirstOrDefault(x => x.Id == user.Id);
            if (_user != null)
            {
                _user.Id = user.Id;
                _context.Update(_user);
                _context.SaveChanges();
            }

        }

        public void Delete(string id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                _context.Remove(user);
                _context.SaveChanges();
            }
        }
    }
}

using NetCore_Backend.Data;
using NetCore_Backend.Models;

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
                Name = u.Name,
                Email = u.Email,
                IsActive = u.IsActive,
                Phone = u.Phone,
                Address = u.Address,
                CreateDate = u.CreateDate,
                UpdateDate = u.UpdateDate,
            });
            return userList.ToList();

        }

        public UserModel GetById(long id)
        {
            var u = _context.Users.FirstOrDefault(u => u.Id == id);
            if (u != null)
            {
              return  new UserModel()
                {
                    Id = u.Id,
                    Name = u.Name,
                    Email = u.Email,
                    IsActive = u.IsActive,
                    Phone = u.Phone,
                    Address = u.Address,
                    CreateDate = u.CreateDate,
                    UpdateDate = u.UpdateDate,
                };
            }

            return null;
        }

        public UserModel Add(UserModel user)
        {
            var _user = new User()
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
                _user.Password = user.Password;
                _user.Name = user.Name;
                _user.Email = user.Email;
                _user.IsActive = user.IsActive;
                _user.Phone = user.Phone;
                _user.Address = user.Address;
                _user.UpdateDate = user.UpdateDate;
                _context.Update(_user);
                _context.SaveChanges();
            }
           
        }

        public void Delete(long id)
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

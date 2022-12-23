using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class GalaryRepositoryImpl : IGalaryRepository
    {
        private readonly MyDbContext _context;
        public GalaryRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }

        public List<GalaryModel> GetAll()
        {
            var galaryList = _context.Galarys.Select(g => new GalaryModel()
            {
                Id = g.Id,
                UserId = g.UserId,
                FromDate = g.FromDate,
                ToDate = g.ToDate,
                Authen = g.Authen,
                Address = g.Address,
                Discription = g.Discription,
                IsActive = g.IsActive,
                CreeateDate = g.CreeateDate,
                UpdatedDate = g.UpdatedDate,
            });
            return galaryList.ToList();
        }

        public GalaryModel GetById(long id)
        {
            var g = _context.Galarys.FirstOrDefault(ga => ga.Id == id);
            return new GalaryModel()
            {
                Id = g.Id,
                UserId = g.UserId,
                FromDate = g.FromDate,
                ToDate = g.ToDate,
                Authen = g.Authen,
                Address = g.Address,
                Discription = g.Discription,
                IsActive = g.IsActive,
                CreeateDate = g.CreeateDate,
                UpdatedDate = g.UpdatedDate,
            };
        }

        public GalaryModel Add(GalaryModel galary)
        {
            var _galary = new Galary()
            {
                Id = galary.Id,
                UserId = galary.UserId,
                FromDate = galary.FromDate,
                ToDate = galary.ToDate,
                Authen = galary.Authen,
                Address = galary.Address,
                Discription = galary.Discription,
                IsActive = galary.IsActive,
                CreeateDate = galary.CreeateDate,
                UpdatedDate = galary.UpdatedDate,
            };
            _context.Galarys.Add(_galary);
            _context.SaveChanges();
            return new GalaryModel()
            {
                Id = _galary.Id,
                UserId = _galary.UserId,
                FromDate = _galary.FromDate,
                ToDate = _galary.ToDate,
                Authen = _galary.Authen,
                Address = _galary.Address,
                Discription = _galary.Discription,
                IsActive = _galary.IsActive,
                CreeateDate = _galary.CreeateDate,
                UpdatedDate = _galary.UpdatedDate,
            };

        }

        public void Update(GalaryModel galary)
        {
            var _galary = _context.Galarys.FirstOrDefault(g => g.Id == galary.Id);
            _galary.FromDate = galary.FromDate;
            _galary.ToDate = galary.ToDate;
            _galary.Authen = galary.Authen;
            _galary.Address = galary.Address;
            _galary.Discription = galary.Discription;
            _galary.IsActive = galary.IsActive;
            _galary.UpdatedDate = galary.UpdatedDate;
            _context.Update(_galary);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var galary = _context.Galarys.FirstOrDefault(g => g.Id == id);
            if (galary != null)
            {
                _context.Remove(galary);
                _context.SaveChanges();
            }
        }
    }
}

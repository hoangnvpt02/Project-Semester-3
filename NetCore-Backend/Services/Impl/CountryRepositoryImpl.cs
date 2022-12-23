using NetCore_Backend.Data;
using NetCore_Backend.Models;

namespace NetCore_Backend.Services.Impl
{
    public class CountryRepositoryImpl : ICountryRepository
    {
        private readonly MyDbContext _context;
        public CountryRepositoryImpl(MyDbContext context)
        {
            _context = context;
        }
        public List<CountryResultModel> GetAll()
        {
            var countryList = _context.Countries.Select(ct => new CountryResultModel()
            {
                Id = ct.Id,
                Name = ct.Name,
                CreatedDate = ct.CreatedDate,
                UpdatedDate = ct.UpdatedDate
            });
            return countryList.ToList();
        }

        public CountryResultModel GetById(long id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country != null)
            {
                return new CountryResultModel()
                {
                    Id = country.Id,
                    Name = country.Name,
                    CreatedDate = country.CreatedDate,
                    UpdatedDate = country.UpdatedDate
                };
            }

            return null;
        }

        public CountryResultModel Add(CountryResultModel country)
        {
            var _country = new Country()
            {
                Name = country.Name,
                CreatedDate = country.CreatedDate,
                UpdatedDate = country.UpdatedDate
            };
            _context.Add(_country);
            _context.SaveChanges();
            return new CountryResultModel()
            {
                Id = _country.Id,
                CreatedDate = _country.CreatedDate,
                UpdatedDate = _country.UpdatedDate,
                Name = _country.Name
            };
        }

        public void Update(CountryResultModel country,long id)
        {
            var _country = _context.Countries.FirstOrDefault(c => c.Id == id);
            _country.Name = country.Name;
            _country.UpdatedDate = country.UpdatedDate;
            _context.Update(_country);
            _context.SaveChanges();
        }

        public void Delete(long id)
        {
            var country = _context.Countries.FirstOrDefault(c => c.Id == id);
            if (country != null)
            {
                _context.Remove(country);
                _context.SaveChanges();
            }
        }
    }
}

using NetCore_Backend.Models;

namespace NetCore_Backend.Services
{
    public interface ICountryRepository
    {
        List<CountryResultModel> GetAll();
        CountryResultModel GetById(long id);
        CountryResultModel Add(CountryResultModel country);
        void Update(CountryResultModel country,long id);
        void Delete(long id);
    }
}

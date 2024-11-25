using WebAPITest.DAL.Entities;

namespace WebAPITest.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); //Una de las tantas firmas del método!

        Task<Country> GetCountryById(Guid id);

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> EditCountyAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);

    }
}

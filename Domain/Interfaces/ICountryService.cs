using WebAPITest.DAL.Entities;

namespace WebAPITest.Domain.Interfaces
{
    public interface ICountryService
    {
        Task<IEnumerable<Country>> GetCountriesAsync(); //Una de las tantas firmas del método!

        Task<Country> GetCountryByIdAsync(Guid id);

        Task<Country> CreateCountryAsync(Country country);

        Task<Country> EditCountryAsync(Country country);

        Task<Country> DeleteCountryAsync(Guid id);

    }
}

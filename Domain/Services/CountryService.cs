using Microsoft.EntityFrameworkCore;
using WebAPITest.DAL;
using WebAPITest.DAL.Entities;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Domain.Services
{
    public class CountryService : ICountryService
    {
        private readonly DataBaseContex _contex;

        public CountryService(DataBaseContex contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<Country>> GetCountriesAsync()
        {
            
            try
            {
                var countries = await _contex.Countries.ToListAsync();
                return countries;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> GetCountryByIdAsync(Guid id)
        {
            try
            {
                var country = await _contex.Countries.FirstOrDefaultAsync(c => c.Id == id);
                //Otras dos formas de traerme un objeto desde la BD
                var country1 = await _contex.Countries.FindAsync(id);
                var country2 = await _contex.Countries.FirstAsync(c => c.Id == id);
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> CreateCountryAsync(Country country)
        {
            try
            {
                country.Id = Guid.NewGuid();
                country.CreatedDate = DateTime.Now;
                _contex.Countries.Add(country); //El método Add() me permite crear el objeto en el contexto de BD
                await _contex.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> EditCountyAsync(Country country)
        {
            try
            {
                country.ModifiedDate = DateTime.Now;
                _contex.Countries.Update(country); //Virtualizo mi objeto
                await _contex.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<Country> DeleteCountryAsync(Guid id)
        {
            try
            {
                var country = await GetCountryByIdAsync(id);
                if (country == null)
                {
                    return null;
                }
                _contex.Countries.Remove(country);
                await _contex.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY
                return country;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public Task<Country> GetCountryById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}

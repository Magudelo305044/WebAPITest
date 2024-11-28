using Microsoft.EntityFrameworkCore;
using WebAPITest.DAL;
using WebAPITest.DAL.Entities;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Domain.Services
{
    public class StateService : IStateService
    {
        private readonly DataBaseContex _contex;

        public StateService(DataBaseContex contex)
        {
            _contex = contex;
        }

        public async Task<IEnumerable<State>> GetStatesAsync()
        {
            
            try
            {
                var state = await _contex.States.ToListAsync();
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
        public async Task<State> GetStateByIdAsync(Guid id)
        {
            try
            {
                var state = await _contex.States.FirstOrDefaultAsync(c => c.Id == id);
                //Otras dos formas de traerme un objeto desde la BD
                var state1 = await _contex.States.FindAsync(id);
                var state2 = await _contex.States.FirstAsync(c => c.Id == id);
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> CreateStateAsync(State state)
        {
            try
            {
                state.Id = Guid.NewGuid();
                state.CreatedDate = DateTime.Now;
                _contex.States.Add(state); //El método Add() me permite crear el objeto en el contexto de BD
                await _contex.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> EditStateAsync(State state)
        {
            try
            {
                state.ModifiedDate = DateTime.Now;
                _contex.States.Update(state); //Virtualizo mi objeto
                await _contex.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }

        public async Task<State> DeleteStateAsync(Guid id)
        {
            try
            {
                var state = await GetStateByIdAsync(id);
                if (state == null)
                {
                    return null;
                }
                _contex.States.Remove(state);
                await _contex.SaveChangesAsync(); //Este método me permite guardar el país en mi tabla COUNTRY
                return state;
            }
            catch (DbUpdateException dbUpdateException)
            {

                throw new Exception(dbUpdateException.InnerException?.Message ?? dbUpdateException.Message);
            }
        }
    }
}

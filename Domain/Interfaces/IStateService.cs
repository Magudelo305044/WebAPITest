using WebAPITest.DAL.Entities;

namespace WebAPITest.Domain.Interfaces
{
    public interface IStateService
    {
        Task<IEnumerable<State>> GetStatesAsync(); //Una de las tantas firmas del método!

        Task<State> GetStateByIdAsync(Guid id);

        Task<State> CreateStateAsync(State state);

        Task<State> EditStateAsync(State state);

        Task<State> DeleteStateAsync(Guid id);

    }
}

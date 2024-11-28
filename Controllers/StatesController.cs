using Microsoft.AspNetCore.Mvc;
using WebAPITest.DAL.Entities;
using WebAPITest.Domain.Interfaces;

namespace WebAPITest.Controllers
{
    [Route("api/[controller]")] //Este es el nombre inicial de mi ruta, url o path
    [ApiController]
    public class StatesController : Controller
    {
        private readonly IStateService _stateService;

        public StatesController(IStateService stateService)
        {
            _stateService = stateService;
        }

        [HttpGet, ActionName("Get")]
        [Route("GetAll")]
        public async Task<ActionResult<IEnumerable<State>>> GetActionResultAsync()
        {
            var states = await _stateService.GetStatesAsync();
            if (states == null || !states.Any())
            {
                return NotFound();
            }
            return Ok(states);
        }

        [HttpGet, ActionName("Get")]
        [Route("GetById/{id}")] 
        public async Task<ActionResult<State>> GetStateByIdAsync(Guid id)
        {
            var state = await _stateService.GetStateByIdAsync(id);
            if (state == null)
            {
                return NotFound(); 
            }
            return Ok(state); 
        }

        [HttpPost, ActionName("Create")]
        [Route("Create")]
        public async Task<ActionResult<State>> CreateStateAsync(State state)
        {
            try
            {
                var newState = await _stateService.CreateStateAsync(state);
                if (newState == null)
                {
                    return NotFound();
                }
                return Ok(newState);
            }
            catch (Exception ex)
            {
                if (ex.Message.Contains("duplicate"))
                {
                    return Conflict(string.Format("{0} ya existe", state.Name));
                }
                return Conflict(ex.Message);
            }
        }

        [HttpDelete, ActionName("Delete")]
        [Route("Delete")]
        public async Task<ActionResult<State>> DeleteStateAsync(Guid id)
        {
            if (id == null) return BadRequest();

            var deletedState = await _stateService.DeleteStateAsync(id);
            if (deletedState == null) return NotFound();
            return Ok(deletedState);
        }
    }
}

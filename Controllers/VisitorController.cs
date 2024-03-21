
using Microsoft.AspNetCore.Mvc;
using Reception_system.Repositories;
using Reception_system.Model;

namespace Reception_system.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class VisitorController : ControllerBase
    {
        private readonly IVisitorRepository<Visitor> _repository;
        public VisitorController(IVisitorRepository<Visitor> repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IEnumerable<Visitor>> GetAll() => await _repository.GetAllAsync();

        [HttpGet("{id}")]
        [ProducesResponseType(typeof(Visitor), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetByID(int id)
        {
            var rFeadback = await _repository.GetByIDAsync(id);
            return rFeadback == null ? NotFound() : Ok(rFeadback);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Visitor visitor)
        {
            await _repository.AddAsync(visitor);
            return CreatedAtAction(nameof(GetByID), new { visitor.Id }, visitor);

        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(Visitor visitor)
        {
            await _repository.UpdateAsync(visitor);
            return NoContent();
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int id)
        {
            await _repository.DeleteAsync(id);
            return NoContent();
        }
    }
}

using ClientesApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClientesApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClientesController : ControllerBase
    {
        private readonly IClienteRepository _repo;

        public ClientesController(IClienteRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cliente>>> GetClientes([FromQuery] string? search)
        {
            var result = await _repo.SearchAsync(search);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> Get(long id)
        {
            var cliente = await _repo.GetByIdAsync(id);
            if (cliente == null) return NotFound();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<ActionResult<Cliente>> Create([FromBody] Cliente cliente)
        {
            var created = await _repo.CreateAsync(cliente);
            return CreatedAtAction(nameof(Get), new { id = created.Id }, created);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(long id, [FromBody] Cliente cliente)
        {
            if (id != cliente.Id) return BadRequest();
            await _repo.UpdateAsync(cliente);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(long id)
        {
            await _repo.DeleteAsync(id);
            return NoContent();
        }

        [HttpGet("test-query")]
        public async Task<ActionResult<IEnumerable<Cliente>>> TestQuery()
        {
            var result = await _repo.TestQueryAsync();
            return Ok(result);
        }
    }
}
using Api_Gestion_Clientes.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_Gestion_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;
        public ClientesController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<List<Clientes>>> AgregarCliente(Clientes cliente)
        {
            //DateTime localDate = DateTime.Now;

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();

            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpGet]
        public async Task<ActionResult<List<Clientes>>> ObtenerTodosClientes()
        {
            //DateTime localDate = DateTime.Now;

            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<List<Clientes>>> ObtenerClientes(int id)
        {
            //DateTime localDate = DateTime.Now;

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                return BadRequest("Cliente no encontrado");
            }

            return Ok(cliente);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> BorrarCliente(int id)
        {
            //DateTime localDate = DateTime.Now;

            Clientes cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                return NotFound("Cliente no existe");
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> ActualizarCliente(int id, Clientes cliente)
        {
            //DateTime localDate = DateTime.Now;

            if (id != cliente.Id)
            {
                return BadRequest("Cliente no encontrado");
            }

            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ClienteExiste(id))
                {
                    return NotFound("Cliente no existe");
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        private async Task<bool> ClienteExiste(int id)
        {
            return await _context.Cliente.AnyAsync(e => e.Id == id);
        }
    }
}

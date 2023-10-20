using Api_Gestion_Clientes.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using Microsoft.Extensions.Logging;

namespace Api_Gestion_Clientes.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<ClientesController> _logger;
        public ClientesController(DataContext context, ILogger<ClientesController> logger)
        {
            _context = context;
            _logger = logger;


        }

        [HttpPost]
        [Route("Guardar")]
        public async Task<ActionResult<List<Clientes>>> AgregarCliente(Clientes cliente)
        {
            //DateTime fecha = DateTime.Now;
            //string informacion = "Se busco un usuario";

            _context.Cliente.Add(cliente);
            await _context.SaveChangesAsync();


            //var log = await InformacionLoggeo(informacion, fecha);

            _logger.LogInformation($"Se agrega nuevo cliente {cliente.Nombre}");

            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpGet]
        [Route("Obtener")]
        public async Task<ActionResult<List<Clientes>>> ObtenerTodosClientes()
        {
            //DateTime localDate = DateTime.Now;

            _logger.LogInformation("Se buscaron todos los clientes");

            return Ok(await _context.Cliente.ToListAsync());
        }

        [HttpGet]
        [Route("Obtener/{id:int}")]
        public async Task<ActionResult<List<Clientes>>> ObtenerClientes(int id)
        {
            //DateTime localDate = DateTime.Now;

            var cliente = await _context.Cliente.FindAsync(id);
            if (cliente == null)
            {
                _logger.LogInformation($"No se encontro el cliente {cliente.Nombre}");
                return BadRequest("Cliente no encontrado");
            }


            _logger.LogInformation($"Se busco el cliente {cliente.Nombre}");
            return Ok(cliente);
        }

        [HttpDelete]
        [Route("Borrar/{id:int}")]
        public async Task<ActionResult> BorrarCliente(int id)
        {
            //DateTime localDate = DateTime.Now;

            Clientes cliente = await _context.Cliente.FindAsync(id);

            if (cliente == null)
            {
                _logger.LogInformation($"No se encontro el cliente {cliente.Nombre}");
                return NotFound("Cliente no existe");
            }

            _context.Cliente.Remove(cliente);
            await _context.SaveChangesAsync();

            _logger.LogInformation($"Se borro el cliente {cliente.Nombre}");
            return NoContent();
        }

        [HttpPut]
        [Route("Actualizar")]
        public async Task<IActionResult> ActualizarCliente(int id, Clientes cliente)
        {
            //DateTime localDate = DateTime.Now;

            if (id != cliente.Id)
            {
                _logger.LogInformation($"No se encontro el cliente {cliente.Nombre}");
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
                    _logger.LogInformation($"El cliente {cliente.Nombre} no existe");
                    return NotFound("Cliente no existe");
                }
                else
                {
                    throw;
                }
            }

            _logger.LogInformation($"Se actualizo el cliente {cliente.Nombre}");
            return NoContent();
        }

        private async Task<bool> ClienteExiste(int id)
        {
            return await _context.Cliente.AnyAsync(e => e.Id == id);
        }

        //private async Task<bool> InformacionLoggeo(string informacion, DateTime fecha)
        //{
        //    var usuario = new Logging() { Log = informacion, fechaLog = fecha };

        //    _context.Log.Add(usuario);
        //    await _context.Log.ToListAsync();

        //    return true;
        //}
    }
}

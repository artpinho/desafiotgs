using Cadastro.Data; 
using Cadastro.Models;
using Cadastro.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Cadastro.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ClienteController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public ClienteController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Buscar Cliente por Id
        [HttpGet("{id}")]
        public async Task<ActionResult<Cliente>> GetCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            return cliente;
        }

        //Buscar todos os clientes
        [HttpGet]

        public async Task<ActionResult<IEnumerable<ClienteViewModel>>> GetClientes()
        {
            var clientes = await _context.Clientes.ToListAsync();

            if (clientes == null || !clientes.Any())
            {
                return NotFound();
            }

            var clienteViewModels = clientes.Select(c => new ClienteViewModel
            {
                Id = c.Id,
                Name = c.Name,
                Email = c.Email,
                // Adicione outros campos conforme necessário
            }).ToList();

            return Ok(clienteViewModels);
        }

    // Inserir cliente
    [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> PostCliente([FromBody] ClienteViewModel model)
    {
    
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    
    var cliente = new Cliente
        {
            Name = model.Name,
            Email = model.Email,
            Logotipo = model.Logotipo ?? null
            
        };

        
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        
        var clienteViewModel = new ClienteViewModel
        {
            Id = cliente.Id,
            Name = cliente.Name,
            Email = cliente.Email,
            Logotipo = cliente.Logotipo
            
        };

        
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, clienteViewModel);
        }
        

        // Atualizar Cliente
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, [FromBody] ClienteViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var cliente = await _context.Clientes.FindAsync(id);

            if (cliente == null)
            {
                return NotFound();
            }

            cliente.Name = model.Name;
            cliente.Email = model.Email;
            cliente.Logotipo = model.Logotipo ?? null;
            _context.Entry(cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        
        //Apagar Cliente
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCliente(int id)
        {
            var cliente = await _context.Clientes.FindAsync(id);
            if (cliente == null)
            {
                return NotFound();
            }

            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ClienteExists(int id)
        {
            return _context.Clientes.Any(e => e.Id == id);
        }
    }
}
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
        /*[HttpPost]
        public async Task<ActionResult<ClienteViewModel>> PostCliente(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, cliente);
        }*/
    [HttpPost]
        public async Task<ActionResult<ClienteViewModel>> PostCliente([FromBody] ClienteViewModel model)
    {
    // Verifica se o modelo recebido é válido
    if (!ModelState.IsValid)
    {
        return BadRequest(ModelState);
    }

    // Mapeia o CadastroViewModel para o modelo de domínio Cliente
    var cliente = new Cliente
        {
            Name = model.Name,
            Email = model.Email,
            Logotipo = model.Logotipo
            // Adicione outros campos conforme necessário
        };

        // Adiciona o cliente ao contexto e salva as alterações
        _context.Clientes.Add(cliente);
        await _context.SaveChangesAsync();

        // Mapeia o Cliente para ClienteViewModel para retornar
        var clienteViewModel = new ClienteViewModel
        {
            Id = cliente.Id,
            Name = cliente.Name,
            Email = cliente.Email,
            Logotipo = cliente.Logotipo
            // Adicione outros campos conforme necessário
        };

        // Retorna a resposta de criação com o ClienteViewModel
        return CreatedAtAction(nameof(GetCliente), new { id = cliente.Id }, clienteViewModel);
        }
        

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCliente(int id, Cliente cliente)
        {
            if (id != cliente.Id)
            {
                return BadRequest();
            }

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
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
    public class EnderecoController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public EnderecoController(ApplicationDbContext context)
        {
            _context = context;
        }

        
        // Buscar todos os Enderecos
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecos()
        {
            return await _context.Enderecos.ToListAsync();
        }

        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<Endereco>>> GetEnderecosPorCliente(int clienteId)
        {
            var enderecos = await _context.Enderecos
                .Where(e => e.ClienteId == clienteId)
                .ToListAsync();

            if (enderecos == null || !enderecos.Any())
            {
                return NotFound();
            }

            return Ok(enderecos);
        }


        [HttpGet("{id}")]
        public async Task<ActionResult<Endereco>> GetEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            return endereco;
        }

        
        /*[HttpPost]
        public async Task<ActionResult<EnderecoViewModel>> PostEndereco(Endereco endereco)
        {
            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Id }, endereco);
        }*/

        [HttpPost]
        public async Task<ActionResult<EnderecoViewModel>> PostEndereco([FromBody] EnderecoViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var endereco = new Endereco
            {
                Logradouro = model.Logradouro,
                ClienteId = model.ClienteId
            };

            _context.Enderecos.Add(endereco);
            await _context.SaveChangesAsync();

            // Crie uma nova instância de EnderecoViewModel para retorno
            var enderecoViewModel = new EnderecoViewModel
            {
                Logradouro = endereco.Logradouro,
                ClienteId = endereco.ClienteId
            };

            return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Id }, enderecoViewModel);
        }

       
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, Endereco endereco)
        {
            if (id != endereco.Id)
            {
                return BadRequest();
            }

            _context.Entry(endereco).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(id))
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
        public async Task<IActionResult> DeleteEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);
            if (endereco == null)
            {
                return NotFound();
            }

            _context.Enderecos.Remove(endereco);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EnderecoExists(int id)
        {
            return _context.Enderecos.Any(e => e.Id == id);
        }
    }
}
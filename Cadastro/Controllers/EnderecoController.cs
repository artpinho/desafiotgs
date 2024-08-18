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

        
        // Buscar todos os Endereços
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EnderecoViewModel>>> GetEnderecos()
        {
            var enderecos = await _context.Enderecos.ToListAsync();
            var enderecosViewModel = enderecos.Select(e => new EnderecoViewModel
            {
                Id = e.Id,
                Logradouro = e.Logradouro,
                ClienteId = e.ClienteId
            }).ToList();

            return Ok(enderecosViewModel);
        }

        // Buscar Endereços por Cliente
        [HttpGet("cliente/{clienteId}")]
        public async Task<ActionResult<IEnumerable<EnderecoViewModel>>> GetEnderecosPorCliente(int clienteId)
        {
            var enderecos = await _context.Enderecos
                .Where(e => e.ClienteId == clienteId)
                .ToListAsync();

            if (enderecos == null || !enderecos.Any())
            {
                return NotFound();
            }

            var enderecosViewModel = enderecos.Select(e => new EnderecoViewModel
            {
                Id = e.Id,
                Logradouro = e.Logradouro,
                ClienteId = e.ClienteId
            }).ToList();

            return Ok(enderecosViewModel);
        }


        // Buscar um Endereço por ID
        [HttpGet("{id}")]
        public async Task<ActionResult<EnderecoViewModel>> GetEndereco(int id)
        {
            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            var enderecoViewModel = new EnderecoViewModel
            {
                Logradouro = endereco.Logradouro,
                ClienteId = endereco.ClienteId
            };

            return Ok(enderecoViewModel);
        }


        // Criar um Novo Endereço
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

            var enderecoViewModel = new EnderecoViewModel
            {
                Id = endereco.Id,  // Definido após a criação
                Logradouro = endereco.Logradouro,
                ClienteId = endereco.ClienteId
            };

            return CreatedAtAction(nameof(GetEndereco), new { id = endereco.Id }, enderecoViewModel);
        }

       
        // Atualizar um Endereço
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEndereco(int id, [FromBody] EnderecoViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var endereco = await _context.Enderecos.FindAsync(id);

            if (endereco == null)
            {
                return NotFound();
            }

            endereco.Logradouro = model.Logradouro;
            endereco.ClienteId = model.ClienteId;

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

        
         // Excluir um Endereço
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
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Pages_Clientes
{
    public class DetailsModel : PageModel
    {
        private readonly Cadastro.Data.ApplicationDbContext _context;

        public DetailsModel(Cadastro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Cliente Cliente { get; set; } = default!; 
      public List<Endereco> Enderecos { get; set; } // Lista de endereços

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }

            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            else 
            {
                Cliente = cliente;
            }
                                  
            
            // Carrega a lista de endereços do cliente
            Enderecos = await _context.Enderecos.Where(l => l.ClienteId == id).ToListAsync();
        
            return Page();
        }

            

    }
}

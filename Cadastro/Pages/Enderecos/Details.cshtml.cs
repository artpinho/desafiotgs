using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Pages_Enderecos
{
    public class DetailsModel : PageModel
    {
        private readonly Cadastro.Data.ApplicationDbContext _context;

        public DetailsModel(Cadastro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

      public Endereco Endereco { get; set; } = default!; 


        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var endereco = await _context.Enderecos.FirstOrDefaultAsync(m => m.Id == id);
            Endereco = await _context.Enderecos
                                  .Include(e => e.Cliente)
                                  .FirstOrDefaultAsync(m => m.Id == id);


            if (endereco == null)
            {
                return NotFound();
            }
            else 
            {
                Endereco = endereco;
            }
            
            return Page();
        }
    }
}

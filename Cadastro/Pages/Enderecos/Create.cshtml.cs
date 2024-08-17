using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Pages_Enderecos
{
    public class CreateModel : PageModel
    {
        private readonly Cadastro.Data.ApplicationDbContext _context;

        public CreateModel(Cadastro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
            return Page();
        }

        [BindProperty]
        public Endereco Endereco { get; set; } = default!;
        

        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Enderecos == null || Endereco == null)
            {
                return Page();
            }

            _context.Enderecos.Add(Endereco);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

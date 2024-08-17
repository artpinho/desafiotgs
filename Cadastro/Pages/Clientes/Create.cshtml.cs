using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Cadastro.Data;
using Cadastro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cadastro.Pages_Clientes
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
            return Page();
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;
        
        public IFormFile? LogotipoUpload { get; set; } // Para o upload da imagem
        
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _context.Clientes == null || Cliente == null)
            {
                return Page();
            }
            
            if (LogotipoUpload != null)
            {
                // Converte o arquivo em um array de bytes
                using (var memoryStream = new MemoryStream())
                {
                    await LogotipoUpload.CopyToAsync(memoryStream);
                    Cliente.Logotipo = memoryStream.ToArray();
                }
            }


            _context.Clientes.Add(Cliente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
            
        }
    }
}

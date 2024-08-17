using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Cadastro.Data;
using Cadastro.Models;

namespace Cadastro.Pages_Clientes
{
    public class EditModel : PageModel
    {
        private readonly Cadastro.Data.ApplicationDbContext _context;

        public EditModel(Cadastro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; } = default!;
        public IFormFile? LogotipoUpload { get; set; } // Para o upload da imagem

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }
            
            var cliente =  await _context.Clientes.FirstOrDefaultAsync(m => m.Id == id);
            if (cliente == null)
            {
                return NotFound();
            }
            Cliente = cliente;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
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


            _context.Attach(Cliente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ClienteExists(Cliente.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool ClienteExists(int id)
        {
          return (_context.Clientes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

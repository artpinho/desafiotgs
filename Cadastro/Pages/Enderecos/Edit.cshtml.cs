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

namespace Cadastro.Pages_Enderecos
{
    public class EditModel : PageModel
    {
        private readonly Cadastro.Data.ApplicationDbContext _context;

        public EditModel(Cadastro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Endereco Endereco { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Enderecos == null)
            {
                return NotFound();
            }

            var endereco =  await _context.Enderecos.FirstOrDefaultAsync(m => m.Id == id);
            if (endereco == null)
            {
                return NotFound();
            }
            Endereco = endereco;
           ViewData["ClienteId"] = new SelectList(_context.Clientes, "Id", "Email");
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

            _context.Attach(Endereco).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EnderecoExists(Endereco.Id))
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

        private bool EnderecoExists(int id)
        {
          return (_context.Enderecos?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}

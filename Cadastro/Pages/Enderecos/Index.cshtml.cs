using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Cadastro.Data;
using Cadastro.Models;
using Microsoft.AspNetCore.Authorization;

namespace Cadastro.Pages_Enderecos
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly Cadastro.Data.ApplicationDbContext _context;

        public IndexModel(Cadastro.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Endereco> Endereco { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Enderecos != null)
            {
                Endereco = await _context.Enderecos
                .Include(e => e.Cliente).ToListAsync();
            }
        }
    }
}

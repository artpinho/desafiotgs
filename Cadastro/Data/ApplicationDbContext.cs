using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Cadastro.Models;

namespace Cadastro.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {            
        }

        public DbSet<Cliente> Clientes { get; set; } = default!;
        public DbSet<Endereco> Enderecos { get; set; } = default!;
    }
}

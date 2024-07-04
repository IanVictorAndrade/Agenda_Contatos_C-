using Microsoft.EntityFrameworkCore;
using MeuSiteEmMVC.Models;

namespace MeuSiteEmMVC.Data
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }

        public DbSet<ContatoModel?> Contato { get; set; }
        // public DbSet<UsuarioModel> Users { get; set; }
        
        
    }
}
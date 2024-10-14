using Microsoft.EntityFrameworkCore;
using LixoMelhor.Models;

namespace LixoMelhor.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options ) : base(options)
        {            
        }


        public DbSet<LixeiraModel> Lixeiras { get; set; }
        public DbSet<CaminhaoModel> Caminhoes { get; set; }
    }
}

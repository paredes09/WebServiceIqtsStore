using Microsoft.EntityFrameworkCore;
using WebServiceIqtsStore.Entities;

namespace WebServiceIqtsStore
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Departamentos> Departamentos { get; set; }
        public DbSet<Provincias> Provincias { get; set; }
        public DbSet<Distritos> Distritos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

        }
    }
}

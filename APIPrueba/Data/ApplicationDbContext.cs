using Microsoft.EntityFrameworkCore;
using APIPrueba.Models;

namespace APIPrueba.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<proyectos> Proyectos { get; set; } = null!;
    }
}

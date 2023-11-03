using Microsoft.EntityFrameworkCore;

namespace OrnekCoreWebApi.Models
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Ulke> Ulkes { get; set; }
        public DbSet<Sehir> Sehirs { get; set; }
        public DbSet<Ilce> Ilces { get; set; }

    }
}

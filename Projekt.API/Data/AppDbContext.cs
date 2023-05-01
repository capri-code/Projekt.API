using Microsoft.EntityFrameworkCore;
using Projekt.API.Data.Models;

namespace Projekt.API.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }
        public DbSet<University> Universities { get; set; }
        public DbSet<Faculty> Faculties { get; set; }
    }
}

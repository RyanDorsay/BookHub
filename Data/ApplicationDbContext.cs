using Microsoft.EntityFrameworkCore;
using BookHub.Models;

namespace BookHub.Data
{
    public class ApplicationDbContext : DbContext
    {
        // Constructor
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // DbSet for your Book model
        public DbSet<Books> Books { get; set; }
    }
}

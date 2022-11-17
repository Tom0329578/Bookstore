using BookstoreWeb.Models;
using System.Data.Entity;

namespace BookstoreWeb.Data
{
    public class ApplicationDbContext: DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
    }
}

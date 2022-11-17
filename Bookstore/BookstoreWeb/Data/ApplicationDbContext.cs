using BookstoreWeb.Models;
using Microsoft.EntityFrameworkCore;

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

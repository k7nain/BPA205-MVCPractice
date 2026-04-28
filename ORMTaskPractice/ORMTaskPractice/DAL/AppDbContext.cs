using Microsoft.EntityFrameworkCore;
using ORMTaskPractice.Models;

namespace ORMTaskPractice.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base (options){ }

        public DbSet<Product> Products { get; set; }

    }
}

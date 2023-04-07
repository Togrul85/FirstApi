using FirstApi.Models;
using Microsoft.EntityFrameworkCore;

namespace FirstApi.Data.DAL
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }
        public DbSet<Product> Products { get; set; }    
    }
}

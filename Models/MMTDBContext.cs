using Microsoft.EntityFrameworkCore;
using MMTAPI.Models.Database;

namespace MMTAPI.Models
{
    public class MMTDBContext : DbContext
    {
        public MMTDBContext(DbContextOptions<MMTDBContext> options)
            :base(options)
        {
            Database.EnsureCreated();
        }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderItem> OrderItem { get; set; }
    }
}

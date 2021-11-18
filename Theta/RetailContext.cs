using Microsoft.EntityFrameworkCore;
using Theta.Models.Database;

namespace Theta.Context
{
    public class RetailContext : DbContext
    {
        public RetailContext(DbContextOptions<RetailContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Order> Order { get; set; }
    }
}

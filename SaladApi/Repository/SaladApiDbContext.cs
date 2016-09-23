using Microsoft.EntityFrameworkCore;
using SaladApi.Models;

namespace SaladApi.Repository
{
    /*public class SaladApiDbContext {
      
    }*/
    public class SaladApiDbContext : DbContext
    {
        public SaladApiDbContext(DbContextOptions<SaladApiDbContext> options) 
          : base(options) { }
        
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Salad> Salads { get; set; }
        public DbSet<Order> Orders { get; set; }

    }
}

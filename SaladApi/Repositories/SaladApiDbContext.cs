using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using SaladApi.Models;

namespace SaladApi.Repositories
{
    public class SaladApiDbContext : DbContext
    {
        private IConfigurationRoot _config; 
        public SaladApiDbContext(DbContextOptions<SaladApiDbContext> options, IConfigurationRoot config) 
          : base(options) 
          {
              _config = config;
          }
          
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            var connectionString = _config.GetConnectionString("DefaultConnection");
            optionsBuilder.UseSqlServer(connectionString);
        }
        
        public DbSet<Drink> Drinks { get; set; }
        public DbSet<Salad> Salads { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}

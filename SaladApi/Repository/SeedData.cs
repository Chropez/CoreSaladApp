using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using SaladApi.Models;

namespace SaladApi.Repository
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new SaladApiDbContext(serviceProvider.GetRequiredService<DbContextOptions<SaladApiDbContext>>())) {
                if(!context.Salads.Any()) {
                    AddSalads(context);
                }
                    
                if(!context.Drinks.Any()) {
                    AddDrinks(context);
                }
                
                context.SaveChanges();
            }
        }

        private static void AddSalads(SaladApiDbContext context)
        {
            context.Salads.AddRange(
                new Salad 
                {
                    Name = "Räksallad",
                    Ingredients = "Räkor, pasta"
                },
                new Salad 
                {
                    Name = "Lax",
                    Ingredients = "Lax, pasta"
                }
            );
        }

        private static void AddDrinks(SaladApiDbContext context)
        {
            context.Drinks.AddRange(
                new Drink {
                    Name = "Coca Cola"
                },
                new Drink {
                    Name = "Pepsi"
                },
                new Drink {
                    Name = "Öl"
                }
            );
        }
    }
}

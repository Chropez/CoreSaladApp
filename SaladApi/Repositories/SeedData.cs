using System.Linq;
using SaladApi.Models;

namespace SaladApi.Repositories
{
    public class SeedData
    {
        private readonly SaladApiDbContext _context;

        public SeedData (SaladApiDbContext context)
        {
            _context = context;
        } 

        public void Seed()
        {
            
            if(!_context.Salads.Any()) {
                AddSalads();
            }
                    
            if(!_context.Drinks.Any()) {
                AddDrinks();
            }

            if(!_context.Users.Any()) {
                AddUsers();
            }
                
            if(!_context.Orders.Any()) {
                AddOrders();
            }
        }

        private void AddOrders()
        {
            var salad1 = _context.Salads.First();
            var salad2 = _context.Salads.First(s => s.Id == 2);

            var drink1 = _context.Drinks.First();
            var drink2 = _context.Drinks.First(s => s.Id == 2);
            var drink3 = _context.Drinks.First(s => s.Id == 2);
            
            var user1 = _context.Users.First();
            var user2 = _context.Users.First(s => s.Id == 2);
            var user3 = _context.Users.First(s => s.Id == 3);
            var user4 = _context.Users.First(s => s.Id == 4);
            
            _context.Orders.AddRange(
                new Order 
                {
                    Salad = salad1,
                    Drink = drink1,
                    User = user1
                },
                new Order 
                {
                    Salad = salad1,
                    Drink = drink2,
                    User = user2
                },
                new Order 
                {
                    Salad = salad2,
                    Drink = drink3,
                    User = user3
                },
                new Order 
                {
                    Salad = salad1,
                    Drink = drink1,
                    User = user4,
                    Comment = "- Lök"
                },
                new Order 
                {
                    Salad = salad2,
                    Drink = drink1,
                    User = user4,
                    Comment = "- Ägg, + lök",
                    Delivered = true
                },
                new Order 
                {
                    Salad = salad2,
                    Drink = drink1,
                    User = user3,
                    Delivered = true
                }
            );
            _context.SaveChanges();
        }

        private void AddUsers()
        {
            _context.Users.AddRange(
                new User 
                {
                    Name = "Håkan"
                },
                new User 
                {
                    Name = "Tomas"
                },
                new User 
                {
                    Name = "Alfred"
                },
                new User 
                {
                    Name = "Eduardo García de la Vega"
                }
            );
            _context.SaveChanges();
        }

        private void AddSalads()
        {
            _context.Salads.AddRange(
                new Salad 
                {
                    Name = "Räksallad",
                    Ingredients = "Räkor, pasta",
                    Type = SaladTypes.Pasta,
                    Price = 79
                },
                new Salad 
                {
                    Name = "Lax",
                    Ingredients = "Lax, lök, sallad",
                    Type = SaladTypes.Green,
                    Price = 69
                }
            );
            _context.SaveChanges();
        }

        private void AddDrinks()
        {
            _context.Drinks.AddRange(
                new Drink 
                {
                    Name = "Coca Cola",
                    Size = 33
                },
                new Drink 
                {
                    Name = "Pepsi",
                    Size = 33
                },
                new Drink 
                {
                    Name = "Öl",
                    Size = 100
                },
                new Drink 
                {
                    Name = "Loka",
                    Size = 50
                }
            );
            _context.SaveChanges();
        }
    }
}

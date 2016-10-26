using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SaladApi.Models;
using SaladApi.Repositories;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class DrinksController : Controller
    {
        private readonly SaladApiDbContext _context;

        public DrinksController(SaladApiDbContext context) 
        {
            _context = context;
        }

        // GET api/drinks
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Drinks.ToList());
        }

        // GET api/drinks/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Drinks.FirstOrDefault(s => s.Id == id));
        }

        // POST api/drinks
        [HttpPost]
        public IActionResult Post([FromBody] Drink drink)
        {
            if (ModelState.IsValid) {
                _context.Drinks.Add(drink);
                _context.SaveChanges();
                return Created($"api/drink/{drink.Id}", drink);
            }
            return BadRequest(ModelState);
        }

        // PUT api/drinks/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Drink updatedDrink)
        {
             if (ModelState.IsValid) {
                 var drink = _context.Drinks.First(s => s.Id == id);
                 drink.Name = updatedDrink.Name;
                 _context.SaveChanges();
                 return Ok(drink);
             }
             return BadRequest(ModelState);
        }

        // DELETE api/drinks/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var drink = _context.Drinks.FirstOrDefault(s => s.Id == id);
            if(drink != null) {
                _context.Remove(drink);
                _context.SaveChanges();
                return Ok("Drink deleted");
            }
                        
            return BadRequest($"Drink with Id: {id} was not found");
        }
    }
}

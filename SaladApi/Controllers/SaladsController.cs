using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SaladApi.Models;
using SaladApi.Repositories;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class SaladsController : Controller
    {
        private readonly SaladApiDbContext _context;

        public SaladsController(SaladApiDbContext context) 
        {
            _context = context;
        }

        // GET api/salads
        [HttpGet]
        public IActionResult Get([FromQuery] string sort, [FromQuery] SaladTypes? type)
        {
            IEnumerable<Salad> salads;

            if (type != null)
            {
                salads = _context.Salads.Where(s => s.Type == type).ToList();
            } else {
                salads = _context.Salads.ToList();
            }
            
            if (sort != null)
            {
                if (sort == "price" )
                    salads = salads.OrderBy(s => s.Price).ToList();
                else if (sort == "-price")
                    salads = salads.OrderByDescending(s => s.Price).ToList();
            }
            return Ok(salads);
        }

        // GET api/salads/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_context.Salads.FirstOrDefault(s => s.Id == id));
        }

        // POST api/salads
        [HttpPost]
        public IActionResult Post([FromBody] Salad salad)
        {
            if (ModelState.IsValid) {
                _context.Salads.Add(salad);
                _context.SaveChanges();
                return Created($"api/salads/{salad.Id}", salad);
            }
            return BadRequest(ModelState);
        }

        // PUT api/salads/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Salad updatedSalad)
        {
             if (ModelState.IsValid) {
                 var salad = _context.Salads.First(s => s.Id == id);
                 salad.Name = updatedSalad.Name;
                 salad.Ingredients = updatedSalad.Ingredients;
                 _context.SaveChanges();
                 return Ok(salad);
             }
             return BadRequest(ModelState);
        }

        // DELETE api/salads/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var salad = _context.Salads.FirstOrDefault(s => s.Id == id);
            if(salad != null) {
                _context.Remove(salad);
                _context.SaveChanges();
                return Ok("Salad deleted");
            }
                        
            return BadRequest($"Salad with Id: {id} was not found");
        }
    }
}

using System.Linq;
using Microsoft.AspNetCore.Mvc;
using SaladApi.Models;
using SaladApi.Repository;

namespace SaladApi.Controllers
{
    [Route("api/[controller]")]
    public class saladsController : Controller
    {
        private readonly SaladApiDbContext _context;

        public saladsController(SaladApiDbContext context) 
        {
            _context = context;
        }

        // GET api/salads
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_context.Salads.ToList());
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

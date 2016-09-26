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
    }
}

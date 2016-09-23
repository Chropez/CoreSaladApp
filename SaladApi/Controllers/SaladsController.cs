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
    }
}

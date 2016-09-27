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


         /**
         Tips från coachen!
         
         Tip 1
         Om man vill läsa in ett jsonobjekt som man skickar från klienten
         och automatiskt binda det till en modell
         så kan man använda [FromBody] attributet
         
         t.ex så kan Json-objektet 
          
         { 
             "id" : 1, 
             "name" : "7up", 
             "size": 33 
         }

         bindas till en Drink med: 
         public IActionResult ParseFromObject([FromBody] Drink drink)
         drink.Name == "7up"; // true

         Tip2
         Vissa frågor löses bäst genom att man skickar in Query-parameters i URLen!
         De kan man läsa in med [FromQuery] attributet

         Om man skickar till urlen api/pizzas?rank=1

         så kan man få ut rank på följande sätt

         public IActionResult ParseFromQueryParameters([FromQuery] int rank)

         */ 
         
         
         
         
    }
}

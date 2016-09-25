using System.ComponentModel.DataAnnotations;

namespace SaladApi.Models
{
    public class Drink
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public int Size { get; set; }
    }
}

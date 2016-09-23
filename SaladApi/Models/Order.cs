using System.ComponentModel.DataAnnotations;

namespace SaladApi.Models
{
    public class Order
    {
        public int Id { get; set; }
        [Required]
        public Salad Salad { get; set; }
        [Required]
        public Drink Drink { get; set; }
        [Required]
        public string UserName { get; set; }
        public string Comment { get; set; }
    }
}

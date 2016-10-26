using System.ComponentModel.DataAnnotations;

namespace SaladApi.ViewModels
{
    public class OrderViewModel
    {
        public string Comment { get; set; }
        public bool Delivered { get; set; }

        [Required]
        public int SaladId { get; set; }

        [Required]
        public int DrinkId { get; set; }

        [Required]
        public int UserId { get; set; }
    }
}

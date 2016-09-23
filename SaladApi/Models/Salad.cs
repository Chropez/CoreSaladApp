using System.ComponentModel.DataAnnotations;

namespace SaladApi.Models
{
    public class Salad
    {
      public int Id { get; set; }
      [Required]
      public string Name { get; set; }
      [Required]
      public string Ingredients { get; set; }
    }
}

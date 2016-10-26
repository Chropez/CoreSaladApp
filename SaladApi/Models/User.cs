using System.ComponentModel.DataAnnotations;
using Newtonsoft.Json;

namespace SaladApi.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }

        [Required]
        public string Username { get; set; }
        
        [Required]
        [JsonIgnore]
        public string Password { get; set; }
    }
}

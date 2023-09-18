using System.ComponentModel.DataAnnotations;

namespace RedisAPI.Models
{

    public class Command
    {
        [Required]
        [Key]
        public int Id { get; set; }
        public string? Commands { get; set; }
        public int PlatformId { get; set; }
        
        public Platform? Platform { get; set; }
    }
} 
using System.ComponentModel.DataAnnotations;

namespace rps_backend.Models
{
    public class Player
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
    }
}

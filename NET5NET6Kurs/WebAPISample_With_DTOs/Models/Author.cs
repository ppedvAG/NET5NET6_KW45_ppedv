using System.ComponentModel.DataAnnotations;

namespace WebAPISample_With_DTOs.Models
{
    public class Author
    {
        public int Id { get; set; }
        
        
        [Required]
        public string Name { get; set; }
    }
}

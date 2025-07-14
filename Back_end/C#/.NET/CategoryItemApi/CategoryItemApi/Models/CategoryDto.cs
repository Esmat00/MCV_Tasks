using System.ComponentModel.DataAnnotations;

namespace CategoryItemApi.Models
{
    public class CategoryDto
    {
        [Required]
        public string Name { get; set; }
    }
}

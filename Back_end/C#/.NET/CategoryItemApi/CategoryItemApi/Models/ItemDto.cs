using System.ComponentModel.DataAnnotations;

namespace CategoryItemApi.Models
{
    public class ItemDto
    {
        [Required]
        public string Title { get; set; }

        public string Description { get; set; }

        [Required]
        public int CategoryId { get; set; }
    }
}

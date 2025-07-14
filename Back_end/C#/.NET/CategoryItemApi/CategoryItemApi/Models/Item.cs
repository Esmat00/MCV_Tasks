using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CategoryItemApi.Models
{
    public class Item
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        public string? Description { get; set; }

        // Foreign key
        public int CategoryId { get; set; }

        // Navigation property
        public Category Category { get; set; }
    }
}

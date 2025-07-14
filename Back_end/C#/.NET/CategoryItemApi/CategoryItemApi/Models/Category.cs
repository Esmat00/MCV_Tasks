using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CategoryItemApi.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        // Navigation property (One Category has many Items)
        public ICollection<Item> Items { get; set; }
    }
}

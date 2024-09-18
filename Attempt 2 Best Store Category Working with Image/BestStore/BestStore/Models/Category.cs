using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace BestStore.Models
{
    public class Category
    {
        public int Id { get; set; }

        [Required, MaxLength(100)]
        public string Name { get; set; } = "";

        // Navigation property for the relationship
        public List<Product>? Products { get; set; }
    }
}

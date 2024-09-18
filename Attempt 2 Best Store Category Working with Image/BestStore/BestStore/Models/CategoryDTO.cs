using System.ComponentModel.DataAnnotations;

namespace BestStore.Models
{
    public class CategoryDTO
    {
        [Required, MaxLength(100)]
        public string Name { get; set; } = "";
    }
}

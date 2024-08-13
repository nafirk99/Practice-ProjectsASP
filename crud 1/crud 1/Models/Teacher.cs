using System.ComponentModel.DataAnnotations;

namespace crud_1.Models
{
    public class Teacher
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string? Name { get; set; }

        [Range(5,50)]
        public int TotalStudents { get; set; }

        [Required]
        public decimal Salary { get; set; }

        [Required]
        public DateTime AddedOn { get; set; }
    }
}

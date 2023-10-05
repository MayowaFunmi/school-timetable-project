using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolTimeTable.Models
{
    public class School
    {
        [Key]
        public Guid SchoolId { get; set; } = Guid.NewGuid();
        [MaxLength(7)]
        [Required]
        public string UniqueId { get; set; }
        [Required]
        public string Name { get; set; }
        public string Address { get; set; }
        [ForeignKey("AdminId")]
        public string AdminId { get; set; }
        public ApplicationUser Admin { get; set; }
        public List<Department> Departments { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        public School()
        {
            GenerateSchoolId();
        }

        public void GenerateSchoolId()
        {
            var numbers = "123456789";
            var letters = "ABCDEFGHIJKLMNPQRSTUVWXYZ";
            var random = new Random();
            var randomNumbers = new string(Enumerable.Repeat(numbers, 5)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            var randomLetters = new string(Enumerable.Repeat(letters, 2)
                .Select(s => s[random.Next(s.Length)]).ToArray());
            UniqueId = randomNumbers + randomLetters;
        }
    }
}

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolTimeTable.Models
{
    public class Subject
    {
        [Key]
        public Guid SubjectId { get; set; }

        [Required]
        public Guid SchoolId { get; set; }

        public string SchoolUniqueId { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public string SubjectCode { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int PeriodsPerWeek { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public List<ClassArm> ClassArms { get; set; }
    }
}

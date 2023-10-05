using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using SchoolTimeTable.Data;

namespace SchoolTimeTable.Models
{
    public class ClassArm
    {
        [Key]
        public Guid ClassArmId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public Guid SchoolId { get; set; }
        public string SchoolUniqueId { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        [Required]
        public Guid StudentClassId { get; set; }

        [ForeignKey("StudentClassId")]
        public StudentClass StudentClass { get; set; }
        public Guid DepartmentId { get; set; }

        [ForeignKey("DepartmentId")]
        public Department? Department { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }

        // Navigation Properties
        public List<Subject> Subjects { get; set; }
    }
}

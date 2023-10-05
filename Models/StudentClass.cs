using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using SchoolTimeTable.Data;

namespace SchoolTimeTable.Models
{
    public class StudentClass
    {
        [Key]
        public Guid StudentClassId { get; set; }
        [Required]
        public string SchoolUniqueId { get; set; }
        public Guid SchoolId { get; set; }

        [ForeignKey("SchoolId")]
        public School School { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        [Range(1, int.MaxValue)]
        public int Arm { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        public List<ClassArm> ClassArms { get; set; }
    }
}

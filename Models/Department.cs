using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SchoolTimeTable.Models
{
    public class Department
    {
        [Key]
        public Guid DepartmentId { get; set; }
        [Required]
        public Guid SchoolId { get; set; }
        public string SchoolUniqueId { get; set; }
        [ForeignKey("SchoolId")]
        public School School { get; set; }
        [Required]
        public string DepartmentName { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime? UpdatedAt { get; set; }
    }
}

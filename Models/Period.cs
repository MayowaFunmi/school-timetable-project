using System.ComponentModel.DataAnnotations;

namespace SchoolTimeTable.Models
{
    public class Period
    {
        [Key]
        public Guid PeriodId { get; set; }
        [Required]
        public DayOfWeek DayOfWeek { get; set; }
        public string DayOfWeekName => DayOfWeek.ToString();
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime StartTime { get; set; }
        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:HH:mm}")]
        public DateTime EndTime { get; set; }
        public string SubjectName { get; set; }
        public bool IsBreak { get; set; }
    }
}

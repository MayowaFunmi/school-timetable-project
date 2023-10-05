using System.ComponentModel.DataAnnotations;

namespace SchoolTimeTable.Data
{
    public class LoginModelInput
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
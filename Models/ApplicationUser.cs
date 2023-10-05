using Microsoft.AspNetCore.Identity;

namespace SchoolTimeTable.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public School School { get; set; }
        public List<IdentityRole> Roles { get; set; }
    }
}

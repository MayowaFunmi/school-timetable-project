using Microsoft.AspNetCore.Identity;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Data
{
    public class UserViewModelData
    {
        public ApplicationUser User { get; set; }
        public IList<string> UserRoles { get; set; }
        public List<RoleCheckbox> AllRoles { get; set; }
    }

    public class RoleCheckbox
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}
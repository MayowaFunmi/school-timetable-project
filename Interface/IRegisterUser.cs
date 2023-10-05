using SchoolTimeTable.Data;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Interface
{
    public interface IRegisterUser
    {
        Task<IEnumerable<ApplicationUser>> GetAllUsers();
        Task<ApplicationUser> GetUserById(string Id);
        Task<bool> Create(RegisterModelInput userModel);
        Task<bool> Update(ApplicationUser user);
        Task<bool> Delete(ApplicationUser user);
        bool Save();
    }
}
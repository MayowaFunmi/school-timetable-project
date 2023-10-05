using Microsoft.AspNetCore.Identity;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;
using TimeTableApp.Constants;

namespace SchoolTimeTable.Repository
{
    public class RegisterUser : IRegisterUser
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegisterUser(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> Create(RegisterModelInput userModel)
        {
            try
            {
                var user = new ApplicationUser
                {
                    UserName = userModel.UserName,
                    FirstName = userModel.FirstName,
                    LastName = userModel.LastName,
                    Email = userModel.Email,
                    CreatedAt = DateTime.Now,
                };
                var result = await _userManager.CreateAsync(user, userModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, Roles.User.ToString());
                    return true;
                }
                return false;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error message is {ex.Message}");
                return false;
            }
        }

        public async Task<bool> Delete(ApplicationUser user)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ApplicationUser>> GetAllUsers()
        {
            throw new NotImplementedException();
        }

        public Task<ApplicationUser> GetUserById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> Update(ApplicationUser user)
        {
            throw new NotImplementedException();
        }
    }
}
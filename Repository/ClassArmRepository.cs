using Microsoft.AspNetCore.Identity;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Repository
{
    public class ClassArmRepository : IClassArmRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ClassArmRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public Task<bool> Create()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Repository
{
    public class SchoolRepository : ISchoolRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public SchoolRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        
        public async Task<bool> Create(School school, string userId)
        {
            try
            {
                School newSchool = new()
                {
                    Name = school.Name,
                    Address = school.Address,
                    AdminId = userId
                };
                _context.Schools.Add(newSchool);
                return Save();
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Task<bool> Delete(School school)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<School>> GetAllSchools()
        {
            return await _context.Schools.Include(s => s.Admin).ToListAsync();
        }

        public Task<School> GetSchoolById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public Task<bool> Update(School school)
        {
            throw new NotImplementedException();
        }
    }
}
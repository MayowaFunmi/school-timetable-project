using Microsoft.AspNetCore.Identity;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Repository
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DepartmentRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> Create(SchoolDeptModelView departmentView)
        {
            try
            {
                Department department = new()
                {
                    SchoolId = departmentView.Department.SchoolId,
                    SchoolUniqueId = departmentView.Department.SchoolUniqueId,
                    DepartmentName = departmentView.Department.DepartmentName
                };
                _context.Departments.Add(department);
                return Save();
            }
            catch (System.Exception)
            {
                
                throw;
            }
            throw new NotImplementedException();
        }

        public Task<bool> Delete(Department department)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Department>> GetAllDepartment()
        {
            throw new NotImplementedException();
        }

        public Task<Department> GetDepartmentById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public Task<bool> Update(Department department)
        {
            throw new NotImplementedException();
        }
    }
}
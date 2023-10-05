using Microsoft.AspNetCore.Identity;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Repository
{
    public class ClassRepository : IClassRepository
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public ClassRepository(UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        public async Task<bool> Create(SChoolClassModelView modelView)
        {
            try
            {
                StudentClass studentClass = new()
                {
                    SchoolUniqueId = modelView.StudentClass.SchoolUniqueId,
                    SchoolId = modelView.StudentClass.SchoolId,
                    Name = modelView.StudentClass.Name,
                    Arm = modelView.StudentClass.Arm
                };
                _context.StudentClasses.Add(studentClass);
                _context.SaveChanges();
                List<ClassArm> classArms = new();
                for (int i = 0; i < studentClass.Arm; i++)
                {
                    var armName = $"{studentClass.Name}{(char)('A' + i)}";
                    classArms.Add(new ClassArm
                    {
                        SchoolId = studentClass.SchoolId,
                        SchoolUniqueId = studentClass.SchoolUniqueId,
                        StudentClassId = studentClass.StudentClassId,
                        Name = armName,
                    });
                }
                foreach (var arm in classArms)
                {
                    if (arm.Name.Contains("A"))
                    {
                        arm.Department = _context.Departments.FirstOrDefault(d => d.DepartmentName == "Science");
                    }
                    else if (arm.Name.Contains("B"))
                    {
                        arm.Department = _context.Departments.FirstOrDefault(d => d.DepartmentName == "Arts");
                    }
                    else if (arm.Name.Contains("C"))
                    {
                        arm.Department = _context.Departments.FirstOrDefault(d => d.DepartmentName == "Commercial");
                    }
                    _context.ClassArms.Add(arm);
                    _context.SaveChanges();
                }
                return true;
            }
            catch (System.Exception)
            {
                
                throw;
            }
        }

        public Task<bool> Delete(StudentClass studentClass)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<StudentClass>> GetAllClasses()
        {
            throw new NotImplementedException();
        }

        public Task<StudentClass> GetClassById(string Id)
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0;
        }

        public Task<bool> Update(StudentClass studentClass)
        {
            throw new NotImplementedException();
        }
    }
}
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Controllers
{
    // authorize admin users
    public class DepartmentController : Controller
    {
        private readonly IDepartmentRepository _departmentRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public DepartmentController(IDepartmentRepository departmentRepository, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _departmentRepository = departmentRepository;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            // get school of the current user
            var user = await _userManager.GetUserAsync(User);
            var school = await _context.Schools.Where(s => s.Admin == user).FirstOrDefaultAsync();
            SchoolDeptModelView model = new();
            if (school != null)
            {
                var depts = await _context.Departments.Include(d => d.School).Where(d => d.SchoolId == school.SchoolId).ToListAsync();
                model.School = school;
                model.Departments = depts;
                return View(model);
            }
            TempData["msg"] = "school not found";
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SchoolDeptModelView modelView)
        {
            var deptData = await _departmentRepository.Create(modelView);
            if (deptData)
            {
                TempData["msg"] = "Department Added Successfully";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Failed to add department";
            return RedirectToAction("Index");
        }
    }
}
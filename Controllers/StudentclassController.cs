using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolTimeTable.Data;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Controllers
{
    public class StudentclassController : Controller
    {
        private readonly IClassRepository _classRepository;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ApplicationDbContext _context;

        public StudentclassController(IClassRepository classRepository, UserManager<ApplicationUser> userManager, ApplicationDbContext context)
        {
            _classRepository = classRepository;
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            var school = await _context.Schools.Where(s => s.Admin == user).FirstOrDefaultAsync();
            SChoolClassModelView modelView = new();
            if (school != null)
            {
                var stdClasses = await _context.StudentClasses
                    .Include(s => s.School)
                    .Include(s => s.ClassArms)
                    .Where(s => s.SchoolId == school.SchoolId)
                    .ToListAsync();
                modelView.School = school;
                modelView.StudentClasses = stdClasses;
                return View(modelView);
            }
            TempData["msg"] = "school not found";
            return View(modelView);
        }

        [HttpPost]
        public async Task<IActionResult> Create(SChoolClassModelView modelView)
        {
            if (modelView == null)
            {
                TempData["msg"] = "model class is empty";
                return RedirectToAction("Index");
            }
            var classData = await _classRepository.Create(modelView);
            if (classData)
            {
                TempData["msg"] = "Class Added Successfully";
                return RedirectToAction("Index");
            }
            TempData["msg"] = "Failed to add Class";
            return RedirectToAction("Index");
        }
    }
}
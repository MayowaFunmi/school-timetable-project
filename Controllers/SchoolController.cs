using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SchoolTimeTable.Interface;
using SchoolTimeTable.Models;

namespace SchoolTimeTable.Controllers
{
    [Authorize(Roles = "Owner")]
    public class SchoolController : Controller
    {
        private readonly ISchoolRepository _schoolRepository;
        private readonly UserManager<ApplicationUser> _userManager;

        public SchoolController(ISchoolRepository schoolRepository, UserManager<ApplicationUser> userManager)
        {
            _schoolRepository = schoolRepository;
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var result = await _schoolRepository.GetAllSchools();
            return View(result);
        } 

        public IActionResult AddSchool()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddSchool(School school)
        {
            var currentUserId = _userManager.GetUserId(this.User);
            if (!string.IsNullOrEmpty(currentUserId))
            {
                var result = await _schoolRepository.Create(school, currentUserId);
                if (result)
                {
                    TempData["msg"] = "School Added Successfully";
                    return RedirectToAction("Index");
                }
                TempData["msg"] = "Failed to add school";
                return View();
            }
            TempData["msg"] = "User ID not found";
            return View();
        }
    }
}
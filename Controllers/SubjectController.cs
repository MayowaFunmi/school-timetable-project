using Microsoft.AspNetCore.Mvc;
using SchoolTimeTable.Interface;

namespace SchoolTimeTable.Controllers
{
    public class SubjectController : Controller
    {
        private readonly ISubjectRepository _subjectRepository;

        public SubjectController(ISubjectRepository subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        // [HttpPost]
        // public async Task<IActionResult> Index()
        // {
        //     return RedirectToAction("Index");
        // }
    }
}
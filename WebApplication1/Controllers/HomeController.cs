using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult RedirectToStudentPage()
        {
            return View("IndexStudent");
        }

        public IActionResult RedirectToSchoolPage()
        {
            return View("IndexSchool");
        }
    }
}

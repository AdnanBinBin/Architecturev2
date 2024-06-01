using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

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
            return View("~/Views/Student/IndexStudent.cshtml");
        }

        public IActionResult RedirectToSchoolPage()
        {
            return RedirectToAction("IndexSchool", "School");
        }
    }
}

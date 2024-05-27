using Microsoft.AspNetCore.Mvc;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class StudentController : Controller

    {

        private readonly IStudentService _studentService;

        public StudentController(IStudentService studentService)
        {
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> GetStudentInfo(int cardID)
        {
            // Call the service method to get the user by card ID
            var user = await _studentService.GetUserByIdCard(cardID);

            if (user == null)
            {
                // Handle the case where user is not found
                return View("UserNotFound");
            }

            // Call the service method to get the budget by user ID
            var budget = await _studentService.GetBudgetByIdUser(user.IdUser);

            if (budget == null)
            {
                // Handle the case where budget is not found
                return View("BudgetNotFound");
            }

            // Pass data to the view
            ViewData["User"] = user;
            ViewData["Budget"] = budget;

            // Return a view to display student's information
            return View("StudentInfo");
        }
    }
}


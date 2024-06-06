using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;
using WebApplication1.Models;
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

        public IActionResult IndexStudent()
        {
            ViewBag.ErrorMessage = TempData["ErrorMessage"];
            return View();
        }

        [HttpPost]
        public IActionResult AddCardId(int cardId)
        {
            HttpContext.Session.SetInt32("CardId", cardId);
            return RedirectToAction("GetStudentInfo");
        }

        public async Task<IActionResult> GetStudentInfo()
        {
            int? cardId = HttpContext.Session.GetInt32("CardId");

            if (cardId == null)
            {
                TempData["ErrorMessage"] = "Card ID is missing.";
                return RedirectToAction("IndexStudent");
            }

            var user = await _studentService.GetUserByIdCard(cardId.Value);

            if (user == null)
            {
                TempData["ErrorMessage"] = "Invalid card ID. Please try again.";
                return RedirectToAction("IndexStudent");
            }

            var budget = await _studentService.GetBudgetByIdUser(user.IdUser);

            var model = new StudentInfoViewModel
            {
                User = user,
                Budget = budget
            };

            return View("StudentInfo", model);
        }

        public IActionResult RedirectDepositStudent()
        {
            return View("DepositStudent");
        }

        public async Task<IActionResult> RedirectPrint()
        {
            var products = await _studentService.ProductRateList();
            return View("Print", products);
        }

        [HttpPost]
        public async Task<IActionResult> SubmitPrint(string productCode, int quantity)
        {
            int? cardId = HttpContext.Session.GetInt32("CardId");

            if (cardId == null)
            {
                TempData["ErrorMessage"] = "Card ID is missing.";
                return RedirectToAction("IndexStudent");
            }

            var printProduct = new PrintProductDTO
            {
                IdCard = cardId.Value,
                ProductCode = productCode,
                Quantity = quantity
            };

            try
            {
                await _studentService.Print(printProduct);
                return RedirectToAction("GetStudentInfo");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("GetStudentInfo");
            }
        }

        [HttpPost]
        public async Task<IActionResult> SubmitDeposit(int amount)
        {
            int? cardId = HttpContext.Session.GetInt32("CardId");

            if (cardId == null)
            {
                TempData["ErrorMessage"] = "Card ID is missing.";
                return RedirectToAction("IndexStudent");
            }

            var deposit = new DepositDTO(cardId.Value, amount);

            try
            {
                await _studentService.Deposit(deposit);
                return RedirectToAction("GetStudentInfo");
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = ex.Message;
                return RedirectToAction("GetStudentInfo");
            }
        }

        public async Task<IActionResult> RedirectTransactions()
        {
            int? cardId = HttpContext.Session.GetInt32("CardId");

            if (cardId == null)
            {
                TempData["ErrorMessage"] = "Card ID is missing.";
                return RedirectToAction("IndexStudent");
            }

            var user = await _studentService.GetUserByIdCard(cardId.Value);

            var transactions = await _studentService.GetTransactionsByIdUser(user.IdUser);

            return View("Transactions", transactions);
        }
    }
}

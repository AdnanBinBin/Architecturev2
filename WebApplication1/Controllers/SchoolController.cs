using DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPINormal.DTO;
using WebApplication1.Models;
using WebApplication1.Services;

namespace WebApplication1.Controllers
{
    public class SchoolController : Controller
    {

        private readonly ISchoolService _schoolService;

        public SchoolController(ISchoolService schoolService)
        {
            _schoolService = schoolService;
        }
        public async Task<IActionResult> IndexSchool()
        {
            // Récupérer la liste de tous les utilisateurs
            var users = await _schoolService.GetAllUsers();

            // Liste pour stocker les informations sur les étudiants
            var studentInfos = new List<StudentInfoViewModelAdmin>();

            // Pour chaque utilisateur, obtenir son budget et créer un StudentInfoViewModel
            foreach (var user in users)
            {
                // Obtenir le budget de l'utilisateur
                var budget = await _schoolService.GetBudgetByIdUser(user.IdUser);

                var card = await _schoolService.GetCardByIdUser(user.IdUser);

                // Créer un StudentInfoViewModel avec les informations de l'utilisateur et son budget
                var studentInfo = new StudentInfoViewModelAdmin
                {
                    User = user,
                    Card = card,
                    Budget = budget
                };

                // Ajouter StudentInfoViewModel à la liste
                studentInfos.Add(studentInfo);
            }

            // Passer la liste des StudentInfoViewModel à la vue
            return View(studentInfos);
        }

        
        public IActionResult RedirectAccountCreation()
        {
            return View("~/Views/School/CreateAccount.cshtml");
        }

        public async Task<IActionResult> SubmitUser(AccountCreationDTO accountCreationDTO )
        {
            

            try
            {
                await _schoolService.CreateAccount(accountCreationDTO);
                return RedirectToAction("IndexSchool");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                return View("CreateUser");
            }

        }

        public async Task<IActionResult> RedirectUpdateCard()
        {
            var users = await _schoolService.GetAllUsers();
            return View("~/Views/School/UpdateCard.cshtml", users);
        }

        public async Task<IActionResult> SubmitCard(CardUpdateDTO cardUpdate)
        {
            try
            {
                await _schoolService.UpdateCardStatus(cardUpdate);

                return RedirectToAction("IndexSchool");
            }
            catch (Exception ex)
            {
                ViewBag.ErrorMessage = ex.Message;
                var users = await _schoolService.GetAllUsers(); // Re-fetch users for the view
                return View("UpdateCard", users);
            }
        }
    }
}





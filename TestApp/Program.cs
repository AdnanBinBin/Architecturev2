using DAL;
using DAL.DB.Model;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Linq;
using System.Net;
using WebAPINormal.Services;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<PrintContext>()
            .UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ArchitecturePrintUseCase;Integrated Security=True;")
            .Options;

            using var context = new PrintContext(options);
            var userRepository = new UserRepository(context);
            var cardRepository = new CardRepository(context);
            var budgetRepository = new BudgetRepository(context);
            var userService = new UserService(userRepository, budgetRepository);

            var created = context.Database.EnsureCreated();

            // Seed data into the database
            // Seed(context, userRepository, cardRepository, budgetRepository);


            // Test basic queries
            // TestBasicQueries(userRepository, budgetRepository, cardRepository);

            TestUserService(context, userService, userRepository, budgetRepository);
            Console.WriteLine("Done!");
        }

        private static void Seed(PrintContext context, UserRepository userRepository, CardRepository cardRepository, BudgetRepository budgetRepository)
        {
            // Create and add a new user
            var newUser = new User { FirstName = "Stephan", LastName = "Alaide", Username = "test" };
            userRepository.Add(newUser);


            // Create and add a new card for the user
            var newCard = new Card { IdUser = newUser.IdUser, isEnabled = true };
            cardRepository.Add(newCard);

            // Create and add a new budget for the user
            var newBudget = new Budget { Balance = 100, IdUser = newUser.IdUser };
            budgetRepository.Add(newBudget);


            // Create and add a new card for the user

            context.SaveChanges();
        }

        private static void TestUserService(PrintContext context,UserService userService, UserRepository userRepository, BudgetRepository budgetRepository)
        {
            // Créez un nouvel utilisateur avec des informations spécifiques
            string firstName = "Rodolfo";
            string lastName = "Prout";
            decimal initialBalance = 0;

            // Appelez la méthode createUser de votre UserService
            userService.createUser(firstName, lastName, initialBalance);

            // Récupérez l'utilisateur de la base de données à l'aide du UserRepository
            var user = userRepository.GetAll().FirstOrDefault(u => u.FirstName == firstName && u.LastName == lastName);

            // Vérifiez si l'utilisateur a été correctement ajouté
            if (user != null)
            {
                Console.WriteLine($"User created successfully: Id = {user.IdUser}, FirstName = {user.FirstName}, LastName = {user.LastName}");

                // Récupérez le budget associé à l'utilisateur
                var budget = budgetRepository.GetAll().FirstOrDefault(b => b.IdUser == user.IdUser);

                // Vérifiez si le budget a été correctement créé
                if (budget != null)
                {
                    Console.WriteLine($"Budget created successfully: Id = {budget.IdBudget}, Balance = {budget.Balance}, IdUser = {budget.IdUser}");
                }
                else
                {
                    Console.WriteLine("Budget creation failed: Budget not found.");
                }
            }
            else
            {
                Console.WriteLine("User creation failed: User not found.");
            }
            CardRepository cardRepo = new CardRepository(context);
            CardService carteService = new CardService(cardRepo);

            carteService.CreateCard(user.IdUser, true);

            Console.WriteLine(user.Card.isEnabled + " " +user.Card.IdCard);

            BudgetService budgetService = new BudgetService(budgetRepository);
            budgetService.depositWithdraw(user.Card.IdCard, 500);
            Console.WriteLine(user.Budget.Balance);
            budgetService.depositWithdraw(user.Card.IdCard, -50);
            Console.WriteLine(user.Budget.Balance);

            carteService.UpdateCardStatus(user.IdUser, false);
            budgetService.depositWithdraw(user.Card.IdCard, 400);
            carteService.UpdateCardStatus(user.IdUser, true);
            budgetService.depositWithdraw(user.Card.IdCard, 400);
            Console.WriteLine(user.Budget.Balance);








            context.SaveChanges();
        }
        private static void TestBasicQueries(UserRepository userRepository, BudgetRepository budgetRepository, CardRepository cardRepository)
        {
            // Example usage of repositories
            var user = userRepository.GetById(5);
            var budget = user.Budget;
            var card = user.Card;

            if (budget != null)
            {
                Console.WriteLine($"User found: Id = {user.IdUser}, FirstName = {user.FirstName}, LastName = {user.LastName}, Balance = {budget.Balance}, Card = {card.IdCard}");
            }
            else
            {
                Console.WriteLine($"User found: Id = {user.IdUser}, FirstName = {user.FirstName}, LastName = {user.LastName}, No budget found, Card = {card.IdCard}");
            }

            // You can test other operations here if needed
        }
    }
}
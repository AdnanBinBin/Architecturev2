using DAL;
using DAL.DB.Model;
using DAL.Models;
using DAL.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System;
using System.Linq;
using System.Net;
using System.Net.WebSockets;
using WebAPINormal.Manager;
using WebAPINormal.Services;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var options = new DbContextOptionsBuilder<PrintContext>()
            .UseSqlServer()
            .Options;

            using var context = new PrintContext(options);
            var userRepository = new UserRepository(context);
            var cardRepository = new CardRepository(context);
            var budgetRepository = new BudgetRepository(context);
            var transactionRepository = new TransactionRepository(context);
            var productRateRepository = new ProductRateRepository(context);

            var userService = new UserService(userRepository);
            var cardService = new CardService(cardRepository);
            var budgetService = new BudgetService(budgetRepository, cardService);
            var transactionService = new TransactionService(transactionRepository);
            var productRateService = new ProductRateService(productRateRepository);

            var accountManager = new AccountManager(userService, cardService, budgetService, transactionService);
            var paymentManager = new PaymentManager(cardService, productRateService, budgetService, transactionService);




            var created = context.Database.EnsureCreated();

            // Seed data into the database
            // Seed(context, userRepository, cardRepository, budgetRepository);


            accountManager.CreateAccount("Greg", "Guillotine", 300);
            var user = userService.GetLastAddedUser();
            Console.WriteLine($"User created: {user.Username}, {user.IdUser}");
             var budget = budgetService.GetBudgetByIdUser(user.IdUser);
             Console.WriteLine($"User created: {user.Username}, {user.IdUser} {budget.Balance}");
             accountManager.CreateCard(user.IdUser, true);

             var card = cardService.GetLastAddedCard();
             Console.WriteLine($"Card created: {card.IdCard},{user.IdUser}, {card.IsEnabled}");
             accountManager.Deposit(card.IdCard, 1000);
             budget = budgetService.GetBudgetByIdUser(user.IdUser);
            productRateService.AddProductRate("ABC", "ABCPaper", 5, true);
            Console.WriteLine($"Deposit: {budget.Balance}");


             // Test PaymentManager
             paymentManager.Print(card.IdCard, "ABC", 3);
             paymentManager.BuyExternalProduct(card.IdCard, 50);
             budget = budgetService.GetBudgetByIdUser(user.IdUser);
             Console.WriteLine($"After purchase: {budget.Balance}");


             // Test AccountManager
             accountManager.UpdateCardStatus(card.IdCard, false);

             paymentManager.Print(card.IdCard, "DEF", 2);

             budget = budgetService.GetBudgetByIdUser(user.IdUser);
             Console.WriteLine($"After purchase: {budget.Balance}");





            Console.WriteLine("Done!");
        }

        // Remaining methods...
    }
}

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
            var paymentManager = new PrintManager(cardService, productRateService, budgetService, transactionService);




            var created = context.Database.EnsureCreated();

            // Seed data into the database
            // Seed(context, userRepository, cardRepository, budgetRepository);


            





           
           


            


            
            

            
        }

        // Remaining methods...
    }
}

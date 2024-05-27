﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using WebAPINormal.DTO;
using WebAPINormal.Services;

namespace WebAPINormal.Manager
{
    public class AccountManager
    {
        private readonly UserService _userService;
        private readonly CardService _cardService;
        private readonly BudgetService _budgetService;
        private readonly TransactionService _transactionService;
     

        public AccountManager(UserService userService, CardService cardService, BudgetService budgetService, TransactionService transactionService)
        {
            _userService = userService;
            _cardService = cardService;
            _budgetService = budgetService;
            _transactionService = transactionService;
         
        }

        public void CreateAccount(string firstName, string lastName, decimal initialAmount)
        {
            try
            {
                _userService.CreateUser(firstName, lastName);
                var user = _userService.GetLastAddedUser();
                _budgetService.CreateBudget(user.IdUser, initialAmount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create account: {ex.Message}");
                throw;
            }
        }

        public void Deposit(int idCard, decimal amount)
        {
            try
            {
                var user = _cardService.GetUserByCardId(idCard);
                Console.WriteLine($"User found: {user.Username}, {user.IdUser}");
                _budgetService.Deposit(idCard, amount);
                _transactionService.AddFinancialTransaction(user.IdUser, DateTime.Now, "Deposit", amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to deposit: {ex.Message}");
                throw;
            }
        }

        public void CreateCard(int idUser, bool isEnabled)
        {
            try
            {
                _cardService.CreateCard(idUser, isEnabled);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to create card: {ex.Message}");
                throw;
            }
        }

        public void UpdateCardStatus(int idCard, bool status)
        {
            try
            {
                var card = _cardService.GetCardById(idCard);
                _cardService.UpdateCardStatus(card, status);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update card status: {ex.Message}");
                throw;
            }
        }

        public BudgetDTO GetBudgetByIdCard(int idCard)
        {
            try
            {
                return _budgetService.GetBudgetByIdCard(idCard);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get budget by card ID: {ex.Message}");
                throw;
               
            }
        }

        public BudgetDTO GetBudgetByIdUser(int idUser)
        {
            try
            {
                return _budgetService.GetBudgetByIdUser(idUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get budget by user ID: {ex.Message}");
                throw;
               
            }
        }

        public IEnumerable<TransactionDTO> GetTransactionsByIdUser(int idUser)
        {
            try
            {
                return _transactionService.GetTransactionsByIdUser(idUser);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get transactions by user ID: {ex.Message}");
                throw;
            }
        }

        public UserDTO GetUserByIdCard(int idCard)
        {
            try
            {
                return _cardService.GetUserByCardId(idCard);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get user by card ID: {ex.Message}");
                throw;
            }
        }

        public IEnumerable<UserDTO> GetAllUsers()
        {
            try
            {
                return _userService.GetAllUsers();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get all users: {ex.Message}");
                throw;
            }
        }
    }



}


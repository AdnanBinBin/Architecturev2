using DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPINormal.DTO;

namespace WebApplication1.Services
{
    public interface ISchoolService
    {
        Task<AccountCreationDTO> CreateAccount(AccountCreationDTO accountData);
        Task<CardDTO> CreateCard(CardDTO card);
        Task<DepositDTO> Deposit(DepositDTO deposit);
        Task<List<UserDTO?>> GetAllUsers();
        Task<BudgetDTO> GetBudgetByIdUser(int idUser);
        Task<List<TransactionDTO?>> GetTransactionsByIdUser(int idUser);
        Task UpdateCardStatus(CardDTO card);

        
    }
}

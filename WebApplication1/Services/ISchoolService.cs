using DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPINormal.DTO;

namespace WebApplication1.Services
{
    public interface ISchoolService
    {
        Task CreateAccount(AccountCreationDTO accountData);
        Task Deposit(DepositDTO deposit);
        Task<List<UserDTO?>> GetAllUsers();
        Task<BudgetDTO> GetBudgetByIdUser(int idUser);
        Task<List<TransactionDTO?>> GetTransactionsByIdUser(int idUser);
        Task UpdateCardStatus(CardUpdateDTO card);
        Task <CardDTO> GetCardByIdUser(int idUser);
        Task DepositAll(decimal amount);

        Task RemoveAccount(int idUser);



    }
}

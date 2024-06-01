using DTO;
using WebAPINormal.DTO;

namespace WebApplication1.Services
{
    public interface IStudentService
    {

        Task Print(PrintProductDTO print);
        Task<BudgetDTO>GetBudgetByIdUser(int idUser);
        Task<List<TransactionDTO?>> GetTransactionsByIdUser(int idUser);
        Task BuyExternalProduct(ExternalProductDTO externalProduct);
        Task<UserDTO> GetUserByIdCard(int idCard);
        Task Deposit(DepositDTO deposit);
        Task<List<ProductRateDTO>> ProductRateList();
        Task<ProductRateDTO> ProductRateByCode(string code);




    }
}

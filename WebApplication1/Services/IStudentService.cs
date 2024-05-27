using DTO;
using WebAPINormal.DTO;

namespace WebApplication1.Services
{
    public interface IStudentService
    {

        Task<PrintProductDTO>Print(PrintProductDTO print);
        Task<BudgetDTO>GetBudgetByIdUser(int idUser);
        Task<List<TransactionDTO?>> GetTransactionsByIdUser(int idUser);
        Task<ExternalProductDTO> BuyExternalProduct(ExternalProductDTO externalProduct);
        Task<UserDTO> GetUserByIdCard(int idCard);


    }
}

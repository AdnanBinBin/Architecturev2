using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebAPINormal.Services;

namespace WebAPINormal.Manager
{
    public class PaymentManager
    {
        private readonly CardService _cardService;
        private readonly ProductRateService _productRateService;
        private readonly BudgetService _budgetService;
        private readonly TransactionService _transactionService;
        

        public PaymentManager(CardService cardService, ProductRateService productRateService, BudgetService budgetService, TransactionService transactionService)
        {
            _cardService = cardService;
            _productRateService = productRateService;
            _budgetService = budgetService;
            _transactionService = transactionService;
            
        }

        //To print a document using the ProductRate service
        public void Print(int idCard, string productCode, int quantity)
        {
            try
            {
                if(!_productRateService.IsProductActive(productCode))
                {
                    throw new Exception("Product is not active.");
                }
                var price = _productRateService.GetPriceByProductCode(productCode);
                var total = price * quantity;
                
                _budgetService.Withdraw(idCard, total);
                _transactionService.AddFinancialTransaction(_cardService.GetUserByCardId(idCard).IdUser, DateTime.Now, $"Purchase of {quantity} {productCode}", -total);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to print: {ex.Message}");

                throw;
            }
        }

        //To buy a product from the cafeteria or the vending machine
        public void BuyExternalProduct(int idCard, int amount)
        {
            try
            {
                _budgetService.Withdraw(idCard, amount);
                _transactionService.AddFinancialTransaction(_cardService.GetUserByCardId(idCard).IdUser, DateTime.Now, "External purchase", -amount);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to buy external product: {ex.Message}");
                throw;
            }
        }
    }





}




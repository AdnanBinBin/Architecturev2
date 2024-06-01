using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Client;
using WebAPINormal.DTO;
using WebAPINormal.Services;

namespace WebAPINormal.Manager
{
    public class PrintManager
    {
        private readonly CardService _cardService;
        private readonly ProductRateService _productRateService;
        private readonly BudgetService _budgetService;
        private readonly TransactionService _transactionService;
        

        public PrintManager(CardService cardService, ProductRateService productRateService, BudgetService budgetService, TransactionService transactionService)
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

        public void AddProductRate(string code, string name, decimal price, bool active)
        {
            try
            {
                _productRateService.AddProductRate(code, name, price, active);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to add product rate: {ex.Message}");
                throw;
            }

        } 

        public IEnumerable<ProductRateDTO> GetAllProductRates()
        {
            try
            {
                return _productRateService.GetAllProductRates();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get all product rates: {ex.Message}");
                throw;
            }
        }

        public ProductRateDTO GetProductRateByCode(string productCode)
        {
            try
            {
                return _productRateService.GetByProductCode(productCode);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to get product rate by code: {ex.Message}");
                throw;
            }
        }

        public void UpdateProductRate(int id, string productCode, string name, decimal price, bool active)
        {
            try
            {
                _productRateService.UpdateProductRate(id,productCode, name, price, active);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Failed to update product rate: {ex.Message}");
                throw;
            }
        }




    }





}




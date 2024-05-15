namespace WebAPINormal.Services
{
    public class PrintSystemManager
    {
        private readonly CardService _cardService;
        private readonly ProductRateService _productRateService;
        private readonly BudgetService _budgetService;
        private readonly TransactionService _transactionService;


        public PrintSystemManager(CardService cardService, ProductRateService productRateService, BudgetService budgetService, TransactionService transactionService)
        {
            _cardService = cardService;
            _productRateService = productRateService;
            _budgetService = budgetService;
            _transactionService = transactionService;
        }


    }
}

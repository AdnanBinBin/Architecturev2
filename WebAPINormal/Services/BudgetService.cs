using DAL.DB.Model;
using DAL.Models;
using DAL.Repositories;
using WebAPINormal.DTO;
using WebAPINormal.Services;

public class BudgetService
{
    private readonly BudgetRepository _budgetRepository;
    private readonly CardService _cardService;

    public BudgetService(BudgetRepository budgetRepository, CardService cardService)
    {
        _budgetRepository = budgetRepository;
        _cardService = cardService;
    }

    public void CreateBudget(int idUser, decimal initialBalance)
    {
        var newBudgetDTO = new BudgetDTO(idUser, initialBalance);
        _budgetRepository.Add(newBudgetDTO);
    }

    public BudgetDTO GetBudgetByIdUser(int idUser)
    {
        var budget = _budgetRepository.GetBudgetByIdUser(idUser);
        if (budget == null)
        {
            throw new Exception($"Budget for user with ID {idUser} not found.");
        }
        return budget;
    }

    public BudgetDTO GetBudgetByIdCard(int idCard)
    {
        var user = _cardService.GetUserByCardId(idCard);
        var budget = _budgetRepository.GetBudgetByIdUser(user.IdUser);
        if (budget == null)
        {
            throw new Exception($"Budget for user with ID {user.IdUser} not found.");
        }
        return budget;
    }

    public void Deposit(int idCard, decimal amount)
    {
        var budget = GetBudgetByIdCard(idCard);
        if (!_cardService.GetCardStatus(idCard))
        {
            throw new Exception("Card is not enabled. Cannot perform transaction.");
        }

        if(amount <= 0)
        {
            throw new Exception("Amount must be greater than 0.");
        }

        budget.Balance += amount;
        _budgetRepository.Update(budget);
    }

    public void RemoveBudget(int idBudget)
    {
        bool isRemoved = _budgetRepository.Remove(idBudget);
        if (!isRemoved)
        {
            throw new Exception("Failed to remove budget. Budget not found.");
        }
    }







    public void Withdraw(int idCard, decimal amount)
    {
        var budget = GetBudgetByIdCard(idCard);
        if (!_cardService.GetCardStatus(idCard))
        {
            throw new Exception("Card is not enabled. Cannot perform transaction.");
        }

        if (amount <= 0)
        {
            throw new Exception("Amount must be greater than 0.");
        }

        if (CanPay(budget, amount))
        {
            budget.Balance -= Math.Abs(amount);
            _budgetRepository.Update(budget);
        }
        else
        {
            throw new Exception("Payment is impossible. Not enough funds.");
        }
    }

    public bool CanPay(BudgetDTO budget, decimal amount)
    {
        return budget.Balance >= Math.Abs(amount);
    }
}







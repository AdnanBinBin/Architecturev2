using DAL.DB.Model;
using DAL.Models;
using DAL.Repositories;
using WebAPINormal.Services;

public class BudgetService
{
    private readonly IRepository<Budget> _budgetRepository;


    public BudgetService(IRepository<Budget> budgetRepository)
    {
        _budgetRepository = budgetRepository;
    }

    public void createBudget(int idUser, decimal initialBalance)
    {
        // Logique de création du budget
        var newBudget = new Budget { IdUser = idUser, Balance = initialBalance };

        // Ajouter le budget à la base de données
        _budgetRepository.Add(newBudget);
    }

    public decimal getBalanceByIdUser(int idUser)
    {
        var budget = _budgetRepository.Find(b => b.IdUser == idUser).FirstOrDefault();
        return budget?.Balance ?? 0;
    }


    public decimal getBalanceByUsername(string username)
    {
        var budget = _budgetRepository.Find(b => b.User.Username == username).FirstOrDefault();
        return budget?.Balance ?? 0;
    }

    public void depositWithdraw(int idCard, decimal amount)
    {
        // Récupérer le budget associé à la carte spécifiée
        var budget = _budgetRepository.Find(b => b.User.Card.IdCard == idCard).FirstOrDefault();

        if (budget != null)
        {
            // Vérifier si la carte est activée
            if (budget.User.Card.isEnabled)
            {
                // Vérifier si l'utilisateur est activé
                
                
                    if (amount > 0)
                    {
                        // Effectuer le dépôt
                        budget.Balance += amount;
                        Console.WriteLine("Deposit successful. New balance: " + budget.Balance);
                    }
                    else
                    {
                        // Vérifier si le paiement est possible
                        if (canPay(idCard, amount))
                        {
                            // Effectuer le retrait
                            budget.Balance -= Math.Abs(amount);
                            Console.WriteLine("Withdrawal successful. New balance: " + budget.Balance);
                        }
                        else
                        {
                            Console.WriteLine("Payment is impossible. Not enough funds.");
                        }
                    }

                    // Mettre à jour le budget dans la base de données
                    _budgetRepository.Update(budget);
                
            }
            else
            {
                Console.WriteLine("Card is not enabled. Cannot perform transaction.");
            }
        }
        else
        {
            // Gérer le cas où aucun budget n'est trouvé pour la carte spécifiée
            Console.WriteLine("No budget found for the specified card.");
        }
    }

    

        public bool canPay(int idCard, decimal amount)
    {
        var budget = _budgetRepository.Find(b => b.User.Card.IdCard == idCard).FirstOrDefault();

        if (budget != null)
        {
            return budget.Balance - Math.Abs(amount) >= 0;
                
        }
        Console.WriteLine("budget not found");
        return false;
    }
}
    




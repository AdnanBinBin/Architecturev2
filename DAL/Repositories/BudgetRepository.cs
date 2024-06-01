using DAL.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPINormal.DTO; // Assurez-vous d'importer le namespace du DTO

namespace DAL.Repositories
{
    public class BudgetRepository : IRepository<BudgetDTO> // Utilisation de BudgetDTO
    {
        private readonly PrintContext _context;

        public BudgetRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(BudgetDTO entity)
        {
            // Créez un nouvel objet Budget à partir de BudgetDTO
            var newBudget = new Budget
            {
                IdUser = entity.IdUser,
                Balance = entity.Balance
                // Mappez les autres propriétés ici
            };

            // Ajoutez le nouveau budget à la base de données
            _context.Budgets.Add(newBudget);
            _context.SaveChanges();
        }

        public BudgetDTO GetById(int id)
        {
            // Recherchez le budget par son ID
            var budget = _context.Budgets.Find(id);

            if (budget == null)
            {
                return null;
            }

            // Créez un DTO à partir du budget trouvé
            var budgetDTO = new BudgetDTO(budget.IdBudget,budget.IdUser , budget.Balance);
            

            return budgetDTO;
        }

        public IEnumerable<BudgetDTO> GetAll()
        {
            // Récupérez tous les budgets de la base de données et les mappez vers BudgetDTO
            return _context.Budgets.Select(budget => new BudgetDTO(budget.IdBudget,budget.IdUser, budget.Balance)).ToList();
            
        }

        public BudgetDTO GetBudgetByIdUser(int id)
        {

            // Recherchez le budget par l'ID de l'utilisateur
            var budget = _context.Budgets.FirstOrDefault(b => b.IdUser == id);

            if (budget == null)
            {
                Console.WriteLine("Budget not found");
                return null;
            }

            // Créez un DTO à partir du budget trouvé
            var budgetDTO = new BudgetDTO(budget.IdBudget, budget.IdUser, budget.Balance);

            // Retourne le solde du budget
            return budgetDTO;
        }


        public bool Remove(int id)
        {
            var budget = _context.Budgets.Find(id);
            if (budget != null)
            {
                _context.Budgets.Remove(budget);
                _context.SaveChanges();
                return true; 
            }
            return false;   
        }


        public void Update(BudgetDTO entity)
        {
            var budget = _context.Budgets.Find(entity.IdBudget);
            if (budget != null)
            {
                budget.Balance = entity.Balance;
                _context.SaveChanges();
            }
        }
    }
}

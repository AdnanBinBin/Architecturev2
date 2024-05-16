using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace PrintWebApp.Extension
{
    public static class ConverterExtensions
    {
        public static DAL.DB.Model.Budget ToDal(this Models.BudgetM budget)
        {
            return new DAL.DB.Model.Budget
            {
                IdBudget = budget.IdBudget,
                Balance = budget.Balance,
            };
        }
        public static Models.BudgetM ToModel(this DAL.DB.Model.Budget budget)
        {
            return new Models.BudgetM
            {
                IdBudget = budget.IdBudget,
                Balance = budget.Balance,
            };
        }
    }
}


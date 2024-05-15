using DAL.DB.Model;

namespace PrintWebApp.Models
{
    public class UserM
    {
        public int IdUser { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public BudgetM Budget { get; set; } // Relation one-to-one
        public CardM Card { get; set; } // Relation one-to-one
        public ICollection<TransactionM> Transactions { get; set; } // Liste de transactions
    }
}

namespace WebAPINormal.DTO
{
    public class BudgetDTO
    {

        public BudgetDTO(int UID, decimal fund) {
            IdUser = UID;
            Balance = fund;
        }

        public BudgetDTO(int idbudget, int uid, decimal balance)
        {
            IdBudget = idbudget;
            IdUser = uid;
            Balance = balance;
        }

        public int IdBudget { get; set; }
        public decimal Balance { get; set; }
        public int IdUser { get; set; }
    }
}

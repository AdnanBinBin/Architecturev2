namespace WebAPINormal.DTO
{
    public class BudgetDTO
    {

        public BudgetDTO(int BID, decimal fund) {
            Id = BID;
            Balance = fund;
        
        }

        public int Id { get; set; }
        public decimal Balance { get; set; }
    }
}

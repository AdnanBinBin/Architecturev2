namespace PrintWebApp.Models
{
    public class TransactionM
    {
        public int IdTransaction { get; set; } // Changement de "IdFinTrans" à "IdTransaction"
        public DateTime Timestamp { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
    }
}

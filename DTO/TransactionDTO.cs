namespace WebAPINormal.DTO
{
    public class TransactionDTO
    {
        public int IdTransaction { get; set; }
        public int IdUser { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }


        public TransactionDTO(int TID, int UID, decimal amount, string desc, DateTime date)
        {
            IdTransaction = TID;
            IdUser = UID;
            Amount = amount;
            Description = desc;
            Date = date;
        }


    }
}

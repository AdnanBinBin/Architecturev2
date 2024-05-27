using System.ComponentModel.DataAnnotations;

namespace WebAPINormal.DTO
{
    public class TransactionDTO
    {
        public int IdTransaction { get; set; }
        public int IdUser { get; set; }
        public decimal Amount { get; set; }
        public string Description { get; set; }
        public DateTime TimeStamp { get; set; }


        public TransactionDTO(int UID, decimal amount, string desc, DateTime date)
        {
            IdUser = UID;
            Amount = amount;
            Description = desc;
            TimeStamp = date;
        }

        public TransactionDTO(int idTransaction, int uid, decimal amount, string desc, DateTime date)
        {
            IdTransaction = idTransaction;
            IdUser = uid;
            Amount = amount;
            Description = desc;
            TimeStamp = date;
        }

        public TransactionDTO()
        {
        }


    }
}

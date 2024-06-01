using DAL.Models;
using DAL.Repositories;
using WebAPINormal.DTO;

namespace WebAPINormal.Services
{
    public class TransactionService
    {
        private readonly TransactionRepository _transactionRepository;

        public TransactionService(TransactionRepository transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddFinancialTransaction(int idUser, DateTime dateTimeStamp, string description, decimal amount)
        {
            var newTransaction = new TransactionDTO(idUser, amount, description, dateTimeStamp);
            _transactionRepository.Add(newTransaction);
        }

        public IEnumerable<TransactionDTO> GetTransactionsByIdUser(int idUser)
        {
            var transactions = _transactionRepository.GetTransactionsByUserId(idUser);
            if (transactions == null)
            {
                throw new Exception($"No transactions found for user with ID {idUser}.");
            }
            return transactions;


        }

        public void RemoveTransaction(int idTransaction)
        {
            bool isRemoved = _transactionRepository.Remove(idTransaction);
            if (!isRemoved)
            {
                throw new Exception($"Transaction with ID {idTransaction} not found.");
            }
        }
    }
}


using DAL.Models;
using DAL.Repositories;

namespace WebAPINormal.Services
{
    public class TransactionService
    {
        private readonly IRepository<Transaction> _transactionRepository;
        

        public TransactionService(IRepository<Transaction> transactionRepository)
        {
            _transactionRepository = transactionRepository;
        }

        public void AddFinancialTransaction(int idUser, DateTime dateTimeStamp, string description, decimal amount)
        {
            // Créer une nouvelle transaction financière
            var newTransaction = new Transaction
            {
                IdUser = idUser,
                TimeStamp = dateTimeStamp,
                Description = description,
                Amount = amount
            };

            // Ajouter la transaction à la base de données
            _transactionRepository.Add(newTransaction);
        }

        public IEnumerable<Transaction> getFinancialTransactionsByIdUser(int idUser)
        {
            // Récupérer les transactions financières pour un utilisateur donné
            return _transactionRepository.Find(t => t.IdUser == idUser);
        }
    }
}


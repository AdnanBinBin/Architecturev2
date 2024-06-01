using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using WebAPINormal.DTO;

namespace DAL.Repositories
{
    public class TransactionRepository : IRepository<TransactionDTO> // Adapter pour manipuler des DTO
    {
        private readonly PrintContext _context;

        public TransactionRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(TransactionDTO entity)
        {
            // Créez une nouvelle entité Transaction à partir du DTO

            Console.WriteLine(entity.IdUser);
            var newTransaction = new Transaction
            {
                IdUser = entity.IdUser,
                Amount = entity.Amount,
                Description = entity.Description,
                TimeStamp = entity.TimeStamp
                // Mappez les autres propriétés ici
            };

            Console.WriteLine("IDUSER DEPUIS LE DBO :"+newTransaction.IdUser);

            // Ajoutez la nouvelle entité à la base de données
            _context.Transactions.Add(newTransaction);
            _context.SaveChanges();
        }

        public TransactionDTO GetById(int id)
        {
            // Recherchez la transaction par son ID
            var transaction = _context.Transactions.Find(id);
            if (transaction == null)
            {
                return null;
            }

            // Créez un DTO à partir de l'entité trouvée
            var transactionDTO = new TransactionDTO(
                transaction.IdTransaction,
                transaction.IdUser,
                transaction.Amount,
                transaction.Description,
                transaction.TimeStamp
            // Ajoutez les autres propriétés si nécessaire
            );

            return transactionDTO;
        }

        public IEnumerable<TransactionDTO> GetAll()
        {
            // Récupérez toutes les transactions de la base de données et les mappez vers des DTO
            return _context.Transactions.Select(transaction => new TransactionDTO(
                transaction.IdTransaction,
                transaction.IdUser,
                transaction.Amount,
                transaction.Description,
                transaction.TimeStamp
            // Ajoutez les autres propriétés si nécessaire
            )).ToList();
        }

        public IEnumerable<TransactionDTO> GetTransactionsByUserId(int userId)
        {
            // Récupérez toutes les transactions de l'utilisateur spécifié par son ID
            return _context.Transactions
                .Where(transaction => transaction.IdUser == userId)
                .Select(transaction => new TransactionDTO(
                    transaction.IdTransaction,
                    transaction.IdUser,
                    transaction.Amount,
                    transaction.Description,
                    transaction.TimeStamp
                )).ToList();
        }


        public bool Remove(int id)
        {
            var transaction = _context.Transactions.Find(id);
            if (transaction != null)
            {
                _context.Transactions.Remove(transaction);
                _context.SaveChanges();
                return true;
            }
            return false;
        }

        public void Update(TransactionDTO entity)
        {
            var transaction = _context.Transactions.Find(entity.IdTransaction);
            if (transaction != null)
            {
                transaction.IdUser = entity.IdUser;
                transaction.Amount = entity.Amount;
                transaction.Description = entity.Description;
                transaction.TimeStamp = entity.TimeStamp;
                _context.SaveChanges();
            }
        }
    }
}


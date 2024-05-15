using DAL.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class TransactionRepository : IRepository<Transaction>
    {
        private readonly PrintContext _context;
        public TransactionRepository(PrintContext context) {

            _context = context;
        }
        public void Add(Transaction entity)
        {
            _context.Transactions.Add(entity);
            _context.SaveChanges();
        }

        public Transaction GetById(int id)
        {
            return _context.Transactions.Find(id);
        }

        public IEnumerable<Transaction> GetAll()
        {
            return _context.Transactions.ToList();
        }

        public IEnumerable<Transaction> Find(Expression<Func<Transaction, bool>> predicate)
        {
            return _context.Transactions.Where(predicate).ToList();
        }

        public void Remove(Transaction entity)
        {
            _context.Transactions.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Transaction entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}


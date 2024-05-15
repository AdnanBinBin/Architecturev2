using DAL.DB.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repositories
{
    public class BudgetRepository : IRepository<Budget>
    {
        private readonly PrintContext _context;

        public BudgetRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(Budget entity)
        {
            _context.Budgets.Add(entity);
            _context.SaveChanges();
        }

        public Budget GetById(int id)
        {
            return _context.Budgets.Find(id);
        }



        public IEnumerable<Budget> GetAll()
        {
            return _context.Budgets.ToList();
        }

        public IEnumerable<Budget> Find(Expression<Func<Budget, bool>> predicate)
        {
            return _context.Budgets.Where(predicate).ToList();
        }

        public void Remove(Budget entity)
        {
            _context.Budgets.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Budget entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}


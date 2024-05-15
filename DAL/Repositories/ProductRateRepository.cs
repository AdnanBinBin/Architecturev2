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
    public class ProductRateRepository : IRepository<ProductRate>
    {
        private readonly PrintContext _context;

        public ProductRateRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(ProductRate entity)
        {
            _context.ProductRates.Add(entity);
            _context.SaveChanges();
        }

        public ProductRate GetById(int id)
        {
            return _context.ProductRates.Find(id);
        }

        public IEnumerable<ProductRate> GetAll()
        {
            return _context.ProductRates.ToList();
        }

        public IEnumerable<ProductRate> Find(Expression<Func<ProductRate, bool>> predicate)
        {
            return _context.ProductRates.Where(predicate).ToList();
        }

        public void Remove(ProductRate entity)
        {
            _context.ProductRates.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(ProductRate entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}


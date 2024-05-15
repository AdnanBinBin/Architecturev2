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
    public class CardRepository: IRepository<Card>
    {
        private readonly PrintContext _context;

        public CardRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(Card entity)
        {
            _context.Cards.Add(entity);
            _context.SaveChanges();
        }

        public Card GetById(int id)
        {
            return _context.Cards.Find(id);
        }

        public IEnumerable<Card> GetAll()
        {
            return _context.Cards.ToList();
        }

        public IEnumerable<Card> Find(Expression<Func<Card, bool>> predicate)
        {
            return _context.Cards.Where(predicate).ToList();
        }

        public void Remove(Card entity)
        {
            _context.Cards.Remove(entity);
            _context.SaveChanges();
        }

        public void Update(Card entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}

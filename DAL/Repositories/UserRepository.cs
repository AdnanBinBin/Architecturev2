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
        public class UserRepository : IRepository<User>
        {
            private readonly PrintContext _dbContext; // Remplacez YourDbContext par le contexte de votre base de données

            public UserRepository(PrintContext dbContext)
            {
                _dbContext = dbContext;
            }

            public void Add(User entity)
            {
                _dbContext.Users.Add(entity);
                _dbContext.SaveChanges();
            }

            public User GetById(int id)
            {
                return _dbContext.Users.Find(id);
            }

            public IEnumerable<User> GetAll()
            {
                return _dbContext.Users;
            }

            public IEnumerable<User> Find(Expression<Func<User, bool>> predicate)
            {
                return _dbContext.Users.Where(predicate);
            }

            public void Remove(User entity)
            {
                _dbContext.Users.Remove(entity);
                _dbContext.SaveChanges();
            }

            public void Update(User entity)
            {
                _dbContext.Entry(entity).State = EntityState.Modified;
                _dbContext.SaveChanges();
            }
        }
    }


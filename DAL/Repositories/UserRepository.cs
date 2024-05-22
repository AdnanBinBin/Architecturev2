using Azure.Identity;
using DAL.DB.Model;
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
    public class UserRepository : IRepository<UserDTO> // Utilisation de UserDTO
    {
        private readonly PrintContext _dbContext;

        public UserRepository(PrintContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(UserDTO entity)
        {
            // Créer un nouvel objet User à partir de UserDTO
            var newUser = new User
            {
                Username = entity.Username,
                FirstName = entity.FirstName,
                LastName = entity.LastName
            };

            // Ajouter le nouvel utilisateur à la base de données
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();
        }

        public UserDTO GetById(int id)
        {
            // Rechercher l'utilisateur par son ID
            var user = _dbContext.Users.Find(id);

            if (user == null)
            {
                return null;
            }

            // Créer un DTO à partir de l'utilisateur trouvé
            var userDTO = new UserDTO(user.IdUser,user.Username, user.FirstName, user.LastName);

            return userDTO;
        }

        public UserDTO GetLastAddedUser()
        {
             var user = _dbContext.Users.OrderByDescending(u => u.IdUser).FirstOrDefault();
            if(user != null)
            {
                return new UserDTO(user.IdUser, user.Username, user.FirstName, user.LastName);
            }
            return null;

        }

        public IEnumerable<UserDTO> GetAll()
        {
            // Récupérer tous les utilisateurs de la base de données et les mapper vers UserDTO
            return _dbContext.Users.Select(user => new UserDTO(user.IdUser,user.Username, user.FirstName, user.LastName)).ToList();
        }

        public void Remove(int id)
        {
            // Rechercher l'utilisateur par son ID
            var user = _dbContext.Users.Find(id);
            if (user != null)
            {
                // Supprimer l'utilisateur de la base de données
                _dbContext.Users.Remove(user);
                _dbContext.SaveChanges();
            }
        }

        public UserDTO GetByUsername(string username)
        {
            var user = _dbContext.Users.FirstOrDefault(u => u.Username == username);
            if(user != null)
            {
                return new UserDTO(user.IdUser, user.Username, user.FirstName, user.LastName);
            }
            return null;
        }

        public void Update(UserDTO entity)
        {
            // Rechercher l'utilisateur par son ID
            var user = _dbContext.Users.Find(entity.IdUser);
            if (user != null)
            {
                // Mettre à jour les propriétés de l'utilisateur avec celles du DTO
                user.Username = entity.Username;
                user.FirstName = entity.FirstName;
                user.LastName = entity.LastName;

                // Mettre à jour l'entité dans la base de données
                _dbContext.SaveChanges();
            }
        }

        
    }
}


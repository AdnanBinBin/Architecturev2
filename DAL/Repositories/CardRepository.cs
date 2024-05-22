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
    public class CardRepository : IRepository<CardDTO> // Utilisation de CardDTO
    {
        private readonly PrintContext _context;

        public CardRepository(PrintContext context)
        {
            _context = context;
        }

        public void Add(CardDTO entity)
        {
            // Créez un nouvel objet Card à partir de CardDTO
            var newCard = new Card
            {
                IdUser = entity.IdUser,
                isEnabled = entity.IsEnabled
                // Mappez les autres propriétés ici
            };

            // Ajoutez la nouvelle carte à la base de données
            _context.Cards.Add(newCard);
            _context.SaveChanges();
        }

        public CardDTO GetById(int id)
        {
           
            // Recherchez la carte par son ID
            var card = _context.Cards.Find(id);

            if (card == null)
            {
                return null;
            }

            // Créez un DTO à partir de la carte trouvée
            var cardDTO = new CardDTO(card.IdCard,card.IdUser, card.isEnabled);

            return cardDTO;
        }


        public UserDTO GetUserByCardId(int id)
        {
            
            // Recherchez la carte par son ID
            var card = _context.Cards.Find(id);

            if (card == null)
            {
                return null;
            }

            var user = _context.Users.Find(card.IdUser);

            // Créez un DTO à partir de la carte trouvée
            var userDTO = new UserDTO(user.IdUser, user.Username, user.FirstName, user.LastName);

            return userDTO;
        }

        public IEnumerable<CardDTO> GetAll()
        {
            // Récupérez toutes les cartes de la base de données et les mappez vers CardDTO
            return _context.Cards.Select(card => new CardDTO(card.IdCard,card.IdUser, card.isEnabled)).ToList();
        }

        public CardDTO GetCardByUserId(int id)
        {
            // Recherchez la carte par l'ID de l'utilisateur
            var card = _context.Cards.FirstOrDefault(c => c.IdUser == id);

            if (card == null)
            {
                Console.WriteLine("Card not found");
                return null;
            }

            // Créez un DTO à partir de la carte trouvée
            var cardDTO = new CardDTO(card.IdCard, card.IdUser, card.isEnabled);

            return cardDTO;
        }

        public CardDTO GetLastAddedCard()
        {
            var card = _context.Cards.OrderByDescending(c => c.IdCard).FirstOrDefault();
            if (card != null)
            {
                return new CardDTO(card.IdCard, card.IdUser, card.isEnabled);
            }
            return null;

        }



        public void Remove(int id)
        {
            var card = _context.Cards.Find(id);
            if (card != null)
            {
                _context.Cards.Remove(card);
                _context.SaveChanges();
            }
        }

        public void Update(CardDTO entity)
        {
            var card = _context.Cards.Find(entity.IdCard);
            if (card != null)
            {
                card.IdUser = entity.IdUser;
                card.isEnabled = entity.IsEnabled;
                _context.SaveChanges();
            }
        }

    }
}

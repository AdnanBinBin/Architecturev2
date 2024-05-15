using DAL.Models;
using DAL.Repositories;

namespace WebAPINormal.Services
{
    public class CardService
    {
        private readonly IRepository<Card> _cardRepository;

        public CardService(IRepository<Card> cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void CreateCard(int idUser, bool isEnabled)
        {
            // Logique de création de la carte
            var newCard = new Card { IdUser = idUser, isEnabled = isEnabled };

            // Ajouter la carte à la base de données
            _cardRepository.Add(newCard);
        }

        public void UpdateCardStatus(int userId, bool newStatus)
        {
            // Récupérer la carte associée à l'utilisateur
            var existingCard = _cardRepository.GetAll().FirstOrDefault(c => c.IdUser == userId);

            if (existingCard != null)
            {
                // Mettre à jour le statut de la carte
                existingCard.isEnabled = newStatus;

                // Mettre à jour la carte dans la base de données
                _cardRepository.Update(existingCard);
            }
            else
            {
                Console.WriteLine("Card not found for the user.");
            }
        }

        public void DeleteCard(int userId)
        {
            // Récupérer la carte associée à l'utilisateur
            var existingCard = _cardRepository.GetAll().FirstOrDefault(c => c.IdUser == userId);

            if (existingCard != null)
            {
                // Supprimer la carte de la base de données
                _cardRepository.Remove(existingCard);
            }
            else
            {
                Console.WriteLine("Card not found for the user.");
            }
        }
    }
}


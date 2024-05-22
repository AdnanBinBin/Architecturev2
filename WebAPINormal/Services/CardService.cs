using DAL.Models;
using DAL.Repositories;
using WebAPINormal.DTO;

namespace WebAPINormal.Services
{
    public class CardService
    {
        private readonly CardRepository _cardRepository;

        public CardService(CardRepository cardRepository)
        {
            _cardRepository = cardRepository;
        }

        public void CreateCard(int idUser, bool isEnabled)
        {
            var newCard = new CardDTO(idUser, isEnabled);
            _cardRepository.Add(newCard);
        }

        public void UpdateCardStatus(CardDTO card, bool status)
        {
            var existingCard = _cardRepository.GetById(card.IdCard);
            if (existingCard == null)
            {
                throw new Exception("Card not found for the user.");
            }

            existingCard.IsEnabled = status;
            _cardRepository.Update(existingCard);
        }

        public bool GetCardStatus(int idCard)
        {
            var existingCard = _cardRepository.GetById(idCard);
            if (existingCard == null)
            {
                throw new Exception("Card not found for the user.");
            }
            return existingCard.IsEnabled;
        }

        public CardDTO GetCardById(int id)
        {
            var card = _cardRepository.GetById(id);
            if (card == null)
            {
                throw new Exception("Card not found for ID: " + id);
            }
            return card;
        }

        public CardDTO GetLastAddedCard()
        {
            return _cardRepository.GetLastAddedCard();
        }

        public UserDTO GetUserByCardId(int id)
        {
            var user = _cardRepository.GetUserByCardId(id);
            if (user == null)
            {
                throw new Exception("User not found for card ID: " + id);
            }
            return user;
        }

        public CardDTO GetCardByUserId(int id)
        {
            var card = _cardRepository.GetCardByUserId(id);
            if (card == null)
            {
                throw new Exception("Card not found for user ID: " + id);
            }
            return card;
        }

        public void DeleteCard(int cardId)
        {
            var existingCard = _cardRepository.GetById(cardId);
            if (existingCard == null)
            {
                throw new Exception("Card not found.");
            }
            _cardRepository.Remove(cardId);
        }
    }
}


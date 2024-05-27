namespace WebAPINormal.DTO
{
    public class CardDTO
    {

        public int IdCard { get; set; } 

        public bool IsEnabled { get; set; }

        public int IdUser { get; set; }

        public CardDTO(int UID, bool enabled)
        {
            IdUser = UID;
            IsEnabled = enabled;
        }

        public CardDTO(int idCard, int uid, bool enabled)
        {
            IdCard = idCard;
            IdUser = uid;
            IsEnabled = enabled;
        }

        public CardDTO()
        {
        }







    }
}

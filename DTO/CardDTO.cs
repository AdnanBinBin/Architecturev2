namespace WebAPINormal.DTO
{
    public class CardDTO
    {

        public int IdCard { get; set; }
        public bool isEnabled { get; set; }

        public CardDTO(int CID, int cardID, int idCard, bool enabled)
        {
            IdCard = idCard;
            isEnabled = enabled;
        }



        

    }
}

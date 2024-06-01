using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class CardUpdateDTO
    {
        public int IdUser { get; set; }
        public bool IsEnabled { get; set; }

        public CardUpdateDTO(int idUser, bool IsEnabled)
        {
            IdUser = idUser;
            this.IsEnabled = IsEnabled;
        }

        public CardUpdateDTO()
        {
        }
    }
}

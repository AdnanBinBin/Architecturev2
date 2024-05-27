using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DepositDTO
    {
        public int IdCard { get; set; }
        public decimal Amount { get; set; }

        public DepositDTO(int idCard, decimal amount)
        {
            IdCard = idCard;
            Amount = amount;
        }

        public DepositDTO()
        {
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class PrintProductDTO
    {
        public string IdCard { get; set; }
        public string ProductCode { get; set; }
        public int Quantity { get; set; }

        public PrintProductDTO(string idCard, string productCode, int quantity)
        {
            IdCard = idCard;
            ProductCode = productCode;
            Quantity = quantity;
        }

        public PrintProductDTO()
        {
        }
    }
}

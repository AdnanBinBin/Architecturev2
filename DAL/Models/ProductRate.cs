using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class ProductRate
    {
        [Key]
        public int IdProduct { get; set; }
        public string ProductCode { get; set; }
        public string ProductName { get; set; }

        public decimal Price { get; set; }
        public bool IsActive { get; set; }
    }
}

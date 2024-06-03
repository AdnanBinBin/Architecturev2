using DAL.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Transaction
    {

        [Key]
        public int IdTransaction { get; set; }

        public int IdUser { get; set; } 
        public User User { get; set; } 
        public DateTime TimeStamp { get; set; } 
        public string Description { get; set; } 
        public decimal Amount { get; set; }
    }
}

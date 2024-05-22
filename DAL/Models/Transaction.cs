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

        public int IdUser { get; set; } // Clé étrangère vers l'utilisateur
        public User User { get; set; } // Navigation vers l'utilisateur associé à la transaction
        public DateTime TimeStamp { get; set; } // Date et heure de la transaction
        public string Description { get; set; } // Description de la transaction
        public decimal Amount { get; set; } // Montant de la transaction
    }
}

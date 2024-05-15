using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Model
{
    public class Budget
    {

        [Key]
        public int IdBudget { get; set; }
        public decimal Balance { get; set; }

        public int IdUser { get; set; } // Clé étrangère vers l'utilisateur
        public User User { get; set; } // Navigation vers l'utilisateur associé au budget
    }
}

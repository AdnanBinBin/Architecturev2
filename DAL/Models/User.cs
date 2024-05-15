using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DB.Model
{
    public class User
    {

        [Key]
        public int IdUser { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public Budget Budget { get; set; } // Relation one-to-one
        public Card Card { get; set; } // Relation one-to-one

        public ICollection<Transaction> Transactions { get; set; } // Liste de transactions




    }
}

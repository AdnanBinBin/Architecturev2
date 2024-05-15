using DAL.DB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Models
{
    public class Card
    {

        [Key]
        public int IdCard { get; set; }
        public int IdUser { get; set; }
        public bool isEnabled { get; set; }

        public User User { get; set; }
        
        


    }
}

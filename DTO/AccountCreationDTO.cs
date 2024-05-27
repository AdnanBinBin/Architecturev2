using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebAPINormal.DTO;

namespace DTO
{
    public class AccountCreationDTO
    {
        public string FirstName{ get; set; }
        public string LastName { get; set; }
        public decimal Balance { get; set; }


        public AccountCreationDTO(string firstName, string lastName, decimal balance)
        {
            FirstName = firstName;
            LastName = lastName;
            Balance = balance;
        }

        public AccountCreationDTO()
        {
        }


    }

}

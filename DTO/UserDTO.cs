namespace WebAPINormal.DTO
{
    public class UserDTO
    {

        public int IdUser { get; set; }   
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserDTO(string username, string firstName, string lastName)
        {
            
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }

        public UserDTO(int idUser, string username, string firstName, string lastName)
        {
            IdUser = idUser;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }

        public UserDTO()
        {
        }




    }
}

namespace WebAPINormal.DTO
{
    public class UserDTO
    {

        public int IdUser { get; set; }

        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public UserDTO(int UID, string username, string firstName, string lastName)
        {
            IdUser = UID;
            Username = username;
            FirstName = firstName;
            LastName = lastName;
        }




    }
}

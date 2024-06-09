using DAL.DB.Model;
using DAL.Repositories;
using WebAPINormal.DTO;

namespace WebAPINormal.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void CreateUser(string firstName, string lastName)
        {
            string username = lastName + '.' + firstName;
            var newUser = new UserDTO(username, firstName, lastName);
            _userRepository.Add(newUser);
        }

        public UserDTO GetUser(int id)
        {
            var user = _userRepository.GetById(id);
            if (user == null)
            {
                throw new Exception($"User with ID {id} not found.");
            }
            return user;
        }

        public UserDTO GetUserByUsername(string username)
        {
            var user = _userRepository.GetByUsername(username);
            if (user == null)
            {
                throw new Exception($"User with username {username} not found.");
            }
            return user;
        }

        public void RemoveUser(int idUser)
        {
            bool isRemoved = _userRepository.Remove(idUser);
            if (!isRemoved)
            {
                throw new Exception("Failed to remove user. User not found.");
            }
        }

        public UserDTO GetLastAddedUser()
        {
            return _userRepository.GetLastAddedUser();
        }

        public IEnumerable <UserDTO> GetAllUsers()
        {
            
           var users = _userRepository.GetAll() ?? throw new Exception("No users found.");
            return users;
        }
        

        
    }


}

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
            string username = lastName.Substring(0, 2) + firstName.Substring(0, 2);
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

        public UserDTO GetLastAddedUser()
        {
            return _userRepository.GetLastAddedUser();
        }
    }


}

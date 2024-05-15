using DAL.DB.Model;
using DAL.Repositories;

namespace WebAPINormal.Services
{
    public class UserService
    {

        private readonly IRepository<User> _userRepository;
        private readonly IRepository<Budget> _budgetRepository;

        public UserService(IRepository<User> userRepository, IRepository<Budget> budgetRepository)
        {
            _userRepository = userRepository;
            _budgetRepository = budgetRepository;
        }


        public void createUser(string firstName, string lastName, decimal balance)
        {

            string username = lastName.Substring(0, 2) + firstName.Substring(0, 1);

            var newUser = new User
            {
                FirstName = firstName,
                LastName = lastName,
                Username = username
            };

            _userRepository.Add(newUser);

            int idUser = newUser.IdUser;



            new BudgetService(_budgetRepository).createBudget(idUser, balance);






        } 


    }


}

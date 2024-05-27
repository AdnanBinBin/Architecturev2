using DTO;
using Microsoft.AspNetCore.Mvc;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

using WebAPINormal.DTO;
using WebApplication1.Services;

namespace MVCProject.Services
{
    public class SchoolService : ISchoolService
    {
        private readonly HttpClient _httpClient;
        private readonly string _accountBaseUrl;

        public SchoolService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _accountBaseUrl = configuration["WebAPI:AccountURL"];
        }

        public async Task<BudgetDTO?> GetBudgetByIdUser(int idUser)
        {
           
            
            var response = await _httpClient.GetAsync($"{_accountBaseUrl}/GetBudgetByIdUser/{idUser}");
            if (response.IsSuccessStatusCode)
            {
                var budget = await response.Content.ReadFromJsonAsync<BudgetDTO>();
                return budget;
            }
            else
            {
                return null;
            }
            
            
        }


        public async Task<List<TransactionDTO?>> GetTransactionsByIdUser(int idUser)
        {
        
            var response = await _httpClient.GetAsync($"{_accountBaseUrl}/GetTransactionsByIdUser/{idUser}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var transactions = JsonSerializer.Deserialize<List<TransactionDTO>>(responseBody, options);
            return transactions;


        }

        public async Task<List<UserDTO?>> GetAllUsers()
        {
            
                var response = await _httpClient.GetAsync($"{_accountBaseUrl}/GetAllUsers");
                response.EnsureSuccessStatusCode();
                var responseBody = await response.Content.ReadAsStringAsync();
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var users = JsonSerializer.Deserialize<List<UserDTO>>(responseBody, options);
                return users;
        }
           
        

        // Implémentez de manière similaire les autres méthodes...




        public async Task<DepositDTO> Deposit(DepositDTO deposit)
        {
          
                var response = await _httpClient.PostAsJsonAsync($"{_accountBaseUrl}/Deposit", deposit);
                if (response.IsSuccessStatusCode)
                {
                    var depositReturn = await response.Content.ReadFromJsonAsync<DepositDTO>();
                    return depositReturn;
                }
                else
                {
                    return null;
                }
            }

        public async Task<AccountCreationDTO> CreateAccount(AccountCreationDTO accountData)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_accountBaseUrl}/CreateAccount", accountData);
            if (response.IsSuccessStatusCode)
            {
                var account = await response.Content.ReadFromJsonAsync<AccountCreationDTO>();
                return account;
            }
            else
            {
                return null;
            }
        }

        public async Task<CardDTO> CreateCard(CardDTO card)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_accountBaseUrl}/CreateCard", card);
            if (response.IsSuccessStatusCode)
            {
                var cardReturn = await response.Content.ReadFromJsonAsync<CardDTO>();
                return cardReturn;
            }
            else
            {
                return null;
            }
        }

        public async Task UpdateCardStatus(CardDTO card)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_accountBaseUrl}/UpdateCardStatus", card);
            response.EnsureSuccessStatusCode();
        }





    }
}










    



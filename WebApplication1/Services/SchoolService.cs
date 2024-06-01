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
           
        

        




        public async Task Deposit(DepositDTO deposit)
        {

            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_accountBaseUrl}/Deposit", deposit);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Une erreur s'est produite lors du dépôt.", ex);
            }
        }

        public async Task CreateAccount(AccountCreationDTO accountData)
        {
            try
            {
                var response = await _httpClient.PostAsJsonAsync($"{_accountBaseUrl}/CreateAccount", accountData);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("Une erreur s'est produite lors de la création du compte.", ex);
            }
        }


        public async Task UpdateCardStatus(CardUpdateDTO card)
        {
            var response = await _httpClient.PutAsJsonAsync($"{_accountBaseUrl}/UpdateCardStatus", card);
            response.EnsureSuccessStatusCode();
        }

        public async Task<CardDTO> GetCardByIdUser(int idUser)
        {
            var response = await _httpClient.GetAsync($"{_accountBaseUrl}/GetCardByIdUser/{idUser}");
            if (response.IsSuccessStatusCode)
            {
                var card = await response.Content.ReadFromJsonAsync<CardDTO>();
                return card;
            }
            else
            {
                return null;
            }

        }
    }
}










    



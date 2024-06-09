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
    public class SchoolApiClient : ISchoolApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accountBaseUrl;

        public SchoolApiClient(HttpClient httpClient, IConfiguration configuration)
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

        public async Task DepositAll(decimal amount)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_accountBaseUrl}/DepositAll?amount={amount}", null);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occured during the deposit all", ex);
            }
        }




        public async Task Deposit(DepositDTO deposit)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.PostAsJsonAsync($"{_accountBaseUrl}/Deposit", deposit);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                if (response != null)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"An error occured during the deposit: {responseBody}", ex);
                }
                else
                {
                    throw new Exception("An error occured during the deposit and the response was null", ex);
                }
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
                throw new Exception("An error occured during the creation of the account", ex);
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

        public async Task RemoveAccount(int idUser)
        {
            try
            {
                var response = await _httpClient.PostAsync($"{_accountBaseUrl}/RemoveAccount?idUser={idUser}", null);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                throw new Exception("An error occured during the removal of the account", ex);
            }
        }
    }
}










    



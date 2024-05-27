using DTO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;
using WebAPINormal.DTO;
using WebApplication1.Services;

namespace WebAPINormal.Controllers
{
    
    public class StudentService : IStudentService
    {
        private readonly HttpClient _httpClient;
        private readonly string _accountBaseUrl;
        private readonly string _paymentBaseUrl;

        public StudentService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
            _paymentBaseUrl = configuration["WebAPI:PaymentURL"];
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
            var transactions = JsonSerializer.Deserialize<List<TransactionDTO>>(responseBody);
            return transactions;
        }

        public async Task<PrintProductDTO> Print(PrintProductDTO print)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_paymentBaseUrl}/Print", print);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var printProduct = JsonSerializer.Deserialize<PrintProductDTO>(responseBody);
            return printProduct;
        }

        public async Task<ExternalProductDTO> BuyExternalProduct(ExternalProductDTO externalProduct)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_paymentBaseUrl}/BuyExternalProduct", externalProduct);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var externalProductResponse = JsonSerializer.Deserialize<ExternalProductDTO>(responseBody);
            return externalProductResponse;
        }

        public async Task<UserDTO> GetUserByIdCard(int idCard)
        {
            var response = await _httpClient.GetAsync($"{_accountBaseUrl}/GetUserByIdCard/{idCard}");
            if (response.IsSuccessStatusCode)
            {
                var user = await response.Content.ReadFromJsonAsync<UserDTO>();
                return user;
            }
            else
            {
                return null;
            }
        }



    }
}

using DTO;
using Microsoft.AspNetCore.Http.Headers;
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

    public class StudentApiClient : IStudentApiClient
    {
        private readonly HttpClient _httpClient;
        private readonly string _accountBaseUrl;
        private readonly string _paymentBaseUrl;

        public StudentApiClient(HttpClient httpClient, IConfiguration configuration)
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
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var transactions = JsonSerializer.Deserialize<List<TransactionDTO>>(responseBody, options);
            return transactions;
        }

        public async Task Print(PrintProductDTO print)
        {
            HttpResponseMessage response = null;
            try
            {
                response = await _httpClient.PostAsJsonAsync($"{_paymentBaseUrl}/Print", print);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException ex)
            {
                if (response != null)
                {
                    var responseBody = await response.Content.ReadAsStringAsync();
                    throw new Exception($"An error occurred during the print: {responseBody}", ex);
                }
                else
                {
                    throw new Exception("An error occurred during the print and the response was null.", ex);
                }
            }
        }

        public async Task BuyExternalProduct(ExternalProductDTO externalProduct)
        {
            var response = await _httpClient.PostAsJsonAsync($"{_paymentBaseUrl}/BuyExternalProduct", externalProduct);
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var externalProductResponse = JsonSerializer.Deserialize<ExternalProductDTO>(responseBody);
            
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
                    throw new Exception($"An error occured during the deposit : {responseBody}", ex);
                }
                else
                {
                    throw new Exception("An error occured during the deposit", ex);
                }
            }
        }


        public async Task<List<ProductRateDTO>> ProductRateList()
        {
            var response = await _httpClient.GetAsync($"{_paymentBaseUrl}/GetAllProductsRates");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var options = new JsonSerializerOptions
            {
                PropertyNameCaseInsensitive = true
            };
            var productRates = JsonSerializer.Deserialize<List<ProductRateDTO>>(responseBody, options);
            return productRates;
        }

        public async Task<ProductRateDTO> ProductRateByCode(string code)
        {
            var response = await _httpClient.GetAsync($"{_paymentBaseUrl}/GetProductRateByCode/{code}");
            response.EnsureSuccessStatusCode();
            var responseBody = await response.Content.ReadAsStringAsync();
            var productRate = JsonSerializer.Deserialize<ProductRateDTO>(responseBody);
            return productRate;
        }



    }
}
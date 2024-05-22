using DAL.Models;
using DAL.Repositories;
using WebAPINormal.DTO;

namespace WebAPINormal.Services
{
    public class ProductRateService
    {
        private readonly ProductRateRepository _productRateRepository;

        public ProductRateService(ProductRateRepository productRateRepository)
        {
            _productRateRepository = productRateRepository;
        }

        public decimal GetPriceByProductCode(string productCode)
        {
            var productRate = _productRateRepository.GetByProductCode(productCode);
            if (productRate == null)
            {
                throw new Exception($"Product with code {productCode} not found.");
            }
            return productRate.Price;
        }

        public bool IsProductActive(int id)
        {
            var productRate = _productRateRepository.GetById(id);
            if (productRate == null)
            {
                throw new Exception($"Product with ID {id} not found.");
            }
            return productRate.IsActive;
        }

        public bool IsProductActive(string productCode)
        {
            var productRate = _productRateRepository.GetByProductCode(productCode);
            if (productRate == null)
            {
                throw new Exception($"Product with code {productCode} not found.");
            }
            return productRate.IsActive;
        }

        public void AddProductRate(string code, string name, decimal price, bool active)
        {
            var newProduct = new ProductRateDTO(code, name, price, active);

            _productRateRepository.Add(newProduct);
        }
    }
}

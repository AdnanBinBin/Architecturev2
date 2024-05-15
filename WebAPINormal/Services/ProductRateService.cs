using DAL.Models;
using DAL.Repositories;

namespace WebAPINormal.Services
{
    public class ProductRateService
    {
        private readonly IRepository<ProductRate> _productRateRepository;

        public ProductRateService(IRepository<ProductRate> productRateRepository)
        {
            _productRateRepository = productRateRepository;
        }

        public decimal getPriceByProductCode(string productCode)
        {
            var productRate = _productRateRepository.Find(pr => pr.ProductCode == productCode).FirstOrDefault();
            return productRate?.Price ?? 0; // Si le produit n'est pas trouvé, retourne 0
        }

        public string getProductNameByCode(string productCode)
        {
            var productRate = _productRateRepository.Find(pr => pr.ProductCode == productCode).FirstOrDefault();
            return productRate?.ProductName;
        }

        public bool isProductActive(string productCode)
        {
            var productRate = _productRateRepository.Find(pr => pr.ProductCode == productCode).FirstOrDefault();
            return productRate?.IsActive ?? false; // Si le produit n'est pas trouvé, retourne false
        }
    }
}

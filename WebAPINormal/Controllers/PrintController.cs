using DTO;
using Microsoft.AspNetCore.Mvc;
using WebAPINormal.DTO;
using WebAPINormal.Manager;

namespace WebAPINormal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PrintController : ControllerBase
    {
        private readonly PrintManager _paymentManager;

        public PrintController(PrintManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("Print")]
        public IActionResult Print(PrintProductDTO printProduct)
        {
            try
            {
                _paymentManager.Print(printProduct.IdCard, printProduct.ProductCode, printProduct.Quantity);
                return Ok("Print job initiated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to initiate print job: {ex.Message}");
            }
        }

        [HttpPost("BuyExternalProduct")]
        public IActionResult BuyExternalProduct(int idCard, int amount)
        {
            try
            {
                _paymentManager.BuyExternalProduct(idCard, amount);
                return Ok("External product purchased successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to purchase external product: {ex.Message}");
            }
        }

        [HttpGet("GetAllProductsRates")]
        public IActionResult GetAllProductsRates()
        {
            try
            {
                var products = _paymentManager.GetAllProductRates();
                return Ok(products);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve products: {ex.Message}");
            }
        }

        [HttpPost("AddProductRate")]
        public IActionResult AddProductRate(ProductRateDTO product)
        {
            try
            {
                _paymentManager.AddProductRate(product.ProductCode, product.ProductName, product.Price, product.IsActive);
                return Ok("Product rate added successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to add product rate: {ex.Message}");
            }
        }

        [HttpPut("UpdateProductRate")]
        public IActionResult UpdateProductRate(ProductRateDTO product)
        {
            try
            {
                _paymentManager.UpdateProductRate(product.IdProduct,product.ProductCode, product.ProductName, product.Price, product.IsActive);
                return Ok("Product rate updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update product rate: {ex.Message}");
            }
        }

        [HttpGet("GetProductRateByCode/{productCode}")]
        public IActionResult GetProductRateByCode(string productCode)
        {
            try
            {
                var product = _paymentManager.GetProductRateByCode(productCode);
                return Ok(product);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to retrieve product rate: {ex.Message}");
            }
        }


    }
}


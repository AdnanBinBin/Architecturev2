using Microsoft.AspNetCore.Mvc;
using WebAPINormal.Manager;

namespace WebAPINormal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentManager _paymentManager;

        public PaymentController(PaymentManager paymentManager)
        {
            _paymentManager = paymentManager;
        }

        [HttpPost("Print")]
        public IActionResult Print(int idCard, string productCode, int quantity)
        {
            try
            {
                _paymentManager.Print(idCard, productCode, quantity);
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
    }
}


using Microsoft.AspNetCore.Mvc;
using WebAPINormal.Manager;
using WebAPINormal.DTO;


namespace WebAPINormal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly AccountManager _accountManager;

        public AccountController(AccountManager accountManager)
        {
            _accountManager = accountManager;
        }

        // GET: api/Account/GetBudgetByIdUser/5
        [HttpGet("GetBudgetByIdUser/{idUser}")]
        public ActionResult<BudgetDTO> GetBudgetByIdUser(int idUser)
        {
            try
            {
                var budget = _accountManager.GetBudgetByIdUser(idUser);
                if (budget == null)
                {
                    return NotFound();
                }
                return Ok(budget);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get budget: {ex.Message}");
            }
        }

        // GET: api/Account/GetTransactionsByIdUser/5
        [HttpGet("GetTransactionsByIdUser/{idUser}")]
        public ActionResult<IEnumerable<TransactionDTO>> GetTransactionsByIdUser(int idUser)
        {
            try
            {
                var transactions = _accountManager.GetTransactionsByIdUser(idUser);
                return Ok(transactions);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get transactions: {ex.Message}");
            }
        }

        // POST: api/Account/CreateAccount
        [HttpPost("CreateAccount")]
        public IActionResult CreateAccount(string firstName, string lastName, decimal initialAmount)
        {
            try
            {
                _accountManager.CreateAccount(firstName, lastName, initialAmount);
                return Ok("Account created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create account: {ex.Message}");
            }
        }

        // POST: api/Account/Deposit
        [HttpPost("Deposit")]
        public IActionResult Deposit(int idCard, decimal amount)
        {
            try
            {
                _accountManager.Deposit(idCard, amount);
                return Ok("Deposit successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to deposit: {ex.Message}");
            }
        }

        // POST: api/Account/CreateCard
        [HttpPost("CreateCard")]
        public IActionResult CreateCard(int idUser, bool isEnabled)
        {
            try
            {
                _accountManager.CreateCard(idUser, isEnabled);
                return Ok("Card created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create card: {ex.Message}");
            }
        }

        // PUT: api/Account/UpdateCardStatus
        [HttpPut("UpdateCardStatus")]
        public IActionResult UpdateCardStatus(int idCard, bool status)
        {
            try
            {
                _accountManager.UpdateCardStatus(idCard, status);
                return Ok("Card status updated successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to update card status: {ex.Message}");
            }
        }

        // GET: api/Account/GetBudgetByIdCard/5
        [HttpGet("GetBudgetByIdCard/{idCard}")]
        public ActionResult<BudgetDTO> GetBudgetByIdCard(int idCard)
        {
            try
            {
                var budget = _accountManager.GetBudgetByIdCard(idCard);
                if (budget == null)
                {
                    return NotFound();
                }
                return Ok(budget);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get budget by card ID: {ex.Message}");
            }
        }
    }
}

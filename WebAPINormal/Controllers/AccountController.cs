using Microsoft.AspNetCore.Mvc;
using WebAPINormal.Manager;
using WebAPINormal.DTO;
using DTO;


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

        // GET: api/Account/GetUserByIdCard/5
        [HttpGet("GetUserByIdCard/{idCard}")]
        public ActionResult<UserDTO> GetUserByIdCard(int idCard) {
            try
            {
                var user = _accountManager.GetUserByIdCard(idCard);
                if (user == null)
                {
                    return NotFound();
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get user by card ID: {ex.Message}");
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
        public IActionResult CreateAccount(AccountCreationDTO account)
        {
            try
            {
                _accountManager.CreateAccount(account.FirstName, account.LastName, account.Balance);
                return Ok("Account created successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to create account: {ex.Message}");
            }
        }

        // POST: api/Account/Deposit
        [HttpPost("Deposit")]
        public IActionResult Deposit(DepositDTO deposit)
        {
            try
            {
                _accountManager.Deposit(deposit.IdCard, deposit.Amount);
                return Ok("Deposit successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to deposit: {ex.Message}");
            }
        }


        [HttpPost("DepositAll")]
        public IActionResult DepositAll(decimal amount)
        {
            try
            {
                _accountManager.DepositAll(amount);
                return Ok("Deposit successful");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to deposit all: {ex.Message}");
            }
        }


        [HttpPost("RemoveAccount")]
        public IActionResult RemoveAccount(int idUser)
        {
            try
            {
                _accountManager.RemoveAccount(idUser);
                return Ok("Account removed successfully");
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to remove account: {ex.Message}");
            }
        }



        // PUT: api/Account/UpdateCardStatus
        [HttpPut("UpdateCardStatus")]
        public IActionResult UpdateCardStatus(CardUpdateDTO card)
        {
            try
            {
                _accountManager.UpdateCardStatus(card.IdUser, card.IsEnabled);
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

        // GET : api/Account/GetAllUsers
        [HttpGet("GetAllUsers")]
        public ActionResult<IEnumerable<UserDTO>> GetAllUsers()
        {
            try
            {
                var users = _accountManager.GetAllUsers();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get users: {ex.Message}");
            }
        }

        // GET: api/Account/GetCardByIdUser/5
        [HttpGet("GetCardByIdUser/{idUser}")]
        public ActionResult<CardDTO> GetCardByIdUser(int idUser)
        {
            try
            {
                var card = _accountManager.GetCardByIdUser(idUser);
                if (card == null)
                {
                    return NotFound();
                }
                return Ok(card);
            }
            catch (Exception ex)
            {
                return BadRequest($"Failed to get card by user ID: {ex.Message}");
                
            }
        }
    }
}

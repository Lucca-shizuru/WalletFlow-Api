using Microsoft.AspNetCore.Mvc;
using WalletFlow.Domain.Entities;
using WalletFlow.Domain.Repositories.Interfaces;

namespace WalletFlow.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository _repository;

        public AccountController(IAccountRepository repository)
        {
            _repository = repository;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] string ownerName, string email)
        {
            var account = new Account(ownerName, email);

  
            account.Deposit(1000);

            await _repository.AddAsync(account);

            return Ok(new
            {
                message = "Conta criada!",
                id = account.Id,
                owner = account.Owner,
                balance = account.Balance
            });
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var account = await _repository.GetByIdAsync(id);
            if (account == null) return NotFound();

            return Ok(account);
        }
    }
}
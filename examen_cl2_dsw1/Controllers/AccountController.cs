using Microsoft.AspNetCore.Mvc;
using examen_cl2_dsw1.Models;
using examen_cl2_dsw1.Repositories;

namespace examen_cl2_dsw1.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly IAccountRepository accountRepository;
        public AccountController(IAccountRepository accountRepository)
        {
            //Por inyeccion de dependencia se crea la instancia de la clase
            this.accountRepository = accountRepository;
        }

        [HttpGet]
        [Route("GetAccounts")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts()
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccounts());
        }

        [HttpGet]
        [Route("GetAccounts/page/{page}/size/{size}")]
        public async Task<ActionResult<IEnumerable<Account>>> GetAccounts(int page, int size)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccounts(page, size));
        }

        [HttpGet]
        [Route("/GetAccountById/{id}")]
        public async Task<ActionResult<Account>> GetAccountById(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.GetAccountById(id));
        }

        [HttpPost]
        [Route("/CreateAccount")]
        public async Task<ActionResult<Account>> CreateAccount(Account customer)
        {
            return StatusCode(StatusCodes.Status201Created,
                await accountRepository.CreateAccount(customer));
        }

        [HttpPut]
        [Route("/UpdateAccount")]
        public async Task<ActionResult<Account>> UpdateAccount(Account customer)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.UpdateAccount(customer));
        }


        [HttpDelete]
        [Route("/DeleteAccount")]
        public async Task<ActionResult<bool>> DeleteAccount(int id)
        {
            return StatusCode(StatusCodes.Status200OK,
                await accountRepository.DeleteAccount(id));
        }
    }
}

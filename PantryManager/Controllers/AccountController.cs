using Bonsai.Domain;
using Bonsai.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bonsai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        private IAccountService service;

        public AccountController(IAccountService service)
        {
            this.service = service;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public UserAccount Register([FromBody] UserAccount account)
        {
            return service.CreateAccount(account);
        }


    }
}

using Bonsai.Domain;
using Bonsai.Exceptions;
using Bonsai.Service;
using Bonsai.WebAPI.ApiModel;
using Bonsai.WebAPI.Helpers;
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
        private TokenHelper tokenHelper;

        public AccountController(IAccountService service, TokenHelper tokenHelper)
        {
            this.service = service;
            this.tokenHelper = tokenHelper;
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public IActionResult Register([FromBody] RegisterModel account)
        {
            return Ok(service.CreateAccount(new UserAccount
            {
                Username = account.Username,
                Password = account.Password,
                Email = account.Email
            }));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel account)
        {
            var foundAccount = service.GetAccountByUsername(account.Username);
            if (foundAccount == null)
            {
                throw new AccountNotFoundException();
            }

            if (service.CheckPassword(foundAccount.Id, account.Password))
            {
                return Ok(new { Token = tokenHelper.GenerateToken(foundAccount) });
            }

            throw new AuthenticationException("Passwords do not match!");
        }


        [AllowAnonymous]
        [HttpPost("deleteAccount/{accountId:int}")]
        public IActionResult DeleteAccount([FromRoute] int accountId)
        {
            return Ok(service.DeleteAccount(accountId));
        }

        [AllowAnonymous]
        [HttpPut("{accountId:int}/updateUserData")]
        public IActionResult UpdateUserData([FromRoute] int accountId, [FromBody] UserDataUpdateModel userData)
        {
            var updatedAccount = service.UpdateAccountData(accountId, new UserData
            {
                FirstName = userData.FirstName,
                LastName = userData.LastName,
                DateOfBirth = userData.DateOfBirth,
                Gender = userData.Gender
            });

            return Ok(updatedAccount);
        }

    }
}

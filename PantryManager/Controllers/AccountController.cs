using System;
using Bonsai.Domain;
using Bonsai.Helpers;
using Bonsai.Service;
using Bonsai.WebAPI.ApiModel;
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
            try
            {
                return Ok(service.CreateAccount(new UserAccount
                {
                    Username = account.Username,
                    Password = account.Password,
                    Email = account.Email
                }));
            }
            catch(Exception ex)
            {
                return BadRequest(new { ExceptionMessage = ex.Message });
            }
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel account)
        {
            try
            {
                var foundAccount = service.GetAccountByUsername(account.Username);
                if (foundAccount == null)
                {
                    return BadRequest(new { ExceptionMessage = "User does not exist!" });
                }

                if (service.CheckPassword(foundAccount.Id, account.Password))
                {
                    return Ok(new { Token = tokenHelper.GenerateToken(foundAccount) });
                }

                return BadRequest(new { ExceptionMessage = "Passwords do not match!" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { ExceptionMessage = ex.Message });
            }
        }


        [AllowAnonymous]
        [HttpPost("deleteAccount/{accountId:int}")]
        public IActionResult DeleteAccount([FromRoute] int accountId)
        {
            try
            {
                return Ok(service.DeleteAccount(accountId));
            }
            catch (Exception ex)
            {
                return BadRequest(new { ExceptionMessage = ex.Message });
            }
        }

    }
}

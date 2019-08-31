using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Bonsai.Domain;

namespace Bonsai.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class AccountController : ControllerBase
    {
        public UserAccount Register([FromBody] UserAccount acccount)
        {
            throw new NotImplementedException();
        }


    }
}

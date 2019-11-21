using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bonsai.Helpers;
using Bonsai.Service;
using Bonsai.WebAPI.ApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Bonsai.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PantryController : ControllerBase
    {
        public IPantryService pantryService;
        public UserInformation userInformation;

        public PantryController(IPantryService pantryService, UserInformation userInformation)
        {
            this.pantryService = pantryService;
            this.userInformation = userInformation;
        }

        [HttpGet]
        public IActionResult GetUserPantry()
        {
            if (!userInformation.IsLoggedIn)
                return BadRequest("Not logged in!");

            return Ok(pantryService.GetCurrentUserPantry());

            
        }

        [HttpGet("{itemId:int}")]
        public IActionResult GetItem([FromRoute] int itemId)
        {
            if (!userInformation.IsLoggedIn)
                return BadRequest("Not logged in!");

            return Ok(pantryService.GetItem(itemId));
        }


        [HttpPost]
        public IActionResult AddItem([FromBody] ItemAddModel item)
        {
            if (!userInformation.IsLoggedIn)
                return BadRequest("Not logged in!");

            return Ok(pantryService.AddItem(new Domain.Item
            {
                Name = item.Name,
                Quantity = item.Quantity,
                BuyDate = item.BuyDate,
                ExpirationDate = item.ExpirationDate
            }));

        }

        //[HttpPut("{itemId:int}")]
        //public IActionResult UpdateItem([FromRoute] int itemId, [FromBody] ItemUpdateModel item)
        //{
        //    if (!userInformation.IsLoggedIn)
        //        return BadRequest("Not logged in!");

        //var newItem = new Domain.Item
        //{
        //    Name = item.Name,
        //    Quantity = new Domain.Quantity
        //    {
        //        Amount = item.Amount.HasValue? item.Amount.Value : null,
        //        Unit = Enum.TryParse(Domain.Enums.MeasurementUnit, )
        //    }
        //    BuyDate = item.BuyDate,
        //    ExpirationDate = item.ExpirationDate
        //};

        //return Ok(pantryService.UpdateItem(itemId, newItem);

        //    return Ok();
        //}

        [HttpDelete("{itemId:int}")]
        public IActionResult DeleteItem([FromRoute] int itemId)
        {
            if (!userInformation.IsLoggedIn)
                return BadRequest("Not logged in!");

            return Ok(pantryService.DeleteItem(itemId));
        }


    }
}
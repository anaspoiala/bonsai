using System;
using Bonsai.Domain;
using Bonsai.Domain.Enums;
using Bonsai.Helpers;
using Bonsai.Service;
using Bonsai.WebAPI.ApiModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bonsai.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PantryController : ControllerBase
    {
        public IPantryService service;
        public UserInformation userInformation;

        public PantryController(IPantryService pantryService, UserInformation userInformation)
        {
            this.service = pantryService;
            this.userInformation = userInformation;
        }

        [HttpGet]
        public IActionResult GetUserPantry()
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            return Ok(service.GetCurrentUserPantry());
        }

        [HttpGet("{itemId:int}")]
        public IActionResult GetItem([FromRoute] int itemId)
        {
            userInformation.ThrowErrorIfNotLoggedIn();
            return Ok(service.GetItem(itemId));
        }

        [HttpPost]
        public IActionResult AddItem([FromBody] ItemAddModel item)
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            return base.Ok(service.AddItem(new PantryItem
            {
               // Name = item.Name,
                Quantity = new Quantity
                {
                    Amount = item.Amount,
                    Unit = item.MeasurementUnit
                },
                BuyDate = item.BuyDate,
                ExpirationDate = item.ExpirationDate
            })); ;

        }

        [HttpPut("{itemId:int}")]
        public IActionResult UpdateItem([FromRoute] int itemId, [FromBody] ItemUpdateModel item)
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            var newItem = new PantryItem
            {
                //Name = item.Name,
                Quantity = new Quantity
                {
                    Amount = item.Amount,
                    Unit = item.MeasurementUnit
                },
                BuyDate = item.BuyDate,
                ExpirationDate = item.ExpirationDate
            };

            return Ok(service.UpdateItem(itemId, newItem));
        }

        [HttpDelete("{itemId:int}")]
        public IActionResult DeleteItem([FromRoute] int itemId)
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            return Ok(service.DeleteItem(itemId));
        }

        
    }
}
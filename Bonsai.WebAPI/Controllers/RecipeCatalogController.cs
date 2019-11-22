using System;
using System.Collections.Generic
using Bonsai.Helpers;
using Bonsai.Service;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Bonsai.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class RecipeCatalogController : ControllerBase
    {
        public IRecipeService service;
        public UserInformation userInformation;

        public RecipeCatalogController(IRecipeService service, UserInformation userInformation)
        {
            this.service = service;
            this.userInformation = userInformation;
        }


        // GET: api/Recipe
        [HttpGet]
        public IActionResult GetRecipeCatalog()
        {
            throw new NotImplementedException();
        }

        // GET: api/Recipe/5
        [HttpGet("{recipeId:int}")]
        public IActionResult GetRecipe([FromRoute] int recipeId)
        {
            throw new NotImplementedException();
        }

        // POST: api/Recipe
        [HttpPost]
        public IActionResult AddRecipe([FromBody] object recipe)
        {
            throw new NotImplementedException();
        }

        // PUT: api/Recipe/5
        [HttpPut("{recipeId:int}")]
        public IActionResult UpdateRecipe([FromRoute] int recipeId, [FromBody] object recipe)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{recipeId:int}")]
        public IActionResult DeleteRecipe([FromRoute] int recipeId)
        {
            throw new NotImplementedException();
        }
    }
}

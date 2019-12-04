using System;
using System.Collections.Generic;
using System.Linq;
using Bonsai.Domain;
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
        public ActionResult<RecipeCatalog> GetRecipeCatalog()
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            return Ok(service.GetRecipeCatalog());
        }

        // GET: api/Recipe/5
        [HttpGet("{recipeId:int}")]
        public ActionResult<Recipe> GetRecipe([FromRoute] int recipeId)
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            throw new NotImplementedException();
        }

        // POST: api/Recipe
        [HttpPost]
        public ActionResult<Recipe> AddRecipe([FromBody] RecipeAddModel recipe)
        {
            userInformation.ThrowErrorIfNotLoggedIn();

            return Ok(service.AddRecipe(new Recipe
            {
                Name = recipe.Name,
                Ingredients = ConvertRequestItemList(recipe.Ingredients),
                Steps = recipe.Steps
            })); 
        }

        // PUT: api/Recipe/5
        [HttpPut("{recipeId:int}")]
        public ActionResult<Recipe> UpdateRecipe(
            [FromRoute] int recipeId, [FromBody] RecipeUpdateModel recipe)
        {
            throw new NotImplementedException();
        }

        // DELETE: api/Recipe/5
        [HttpDelete("{recipeId:int}")]
        public ActionResult<Recipe> DeleteRecipe([FromRoute] int recipeId)
        {
            throw new NotImplementedException();
        }


        private List<RecipeItem> ConvertRequestItemList(List<RecipeItemAddModel> items)
        {
            return items.Select(item => new RecipeItem
            {
                Id = item.Id.GetValueOrDefault(),
                //Name = item.Name,
                RequiredQuantity = new Quantity
                {
                    Amount = item.Amount,
                    Unit = item.MeasurementUnit
                }
            }).ToList();
        }
    }
}

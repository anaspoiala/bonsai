using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bonsai.Domain;
using Bonsai.Exceptions;
using Bonsai.Persistence;

namespace Bonsai.Service
{
    public interface IRecipeService
    {
        RecipeCatalog GetRecipeCatalog();
        Recipe GetRecipe();
        Recipe AddRecipe(Recipe recipe);
        Recipe UpdateRecipe(int recipeId, Recipe newRecipe);
        Recipe DeleteRecipe(int recipeId);
    }

    public class RecipeService : IRecipeService
    {
        private IRecipeRepository repository;
        private IPantryService pantryService;

        public RecipeService(IRecipeRepository repository, IPantryService pantryService)
        {
            this.repository = repository;
            this.pantryService = pantryService;
        }

        public RecipeCatalog GetRecipeCatalog()
        {
            return repository.GetRecipeCatalogOfCurrentAccount();
        }

        public Recipe GetRecipe()
        {
            throw new NotImplementedException();
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            ValidateRecipe(recipe);

            // Parse ingredients list and add new items to the pantry (if they don't already exist)
            //foreach (var item in recipe.Ingredients)
            //{
            //    if (!pantryService.ItemExists(item.Id))
            //    {
            //        var newItem = pantryService.AddItem(item);
            //        item.Id = newItem.Id;
            //    }
            //}

            // Add recipe
            return repository.AddRecipe(recipe);
        }


        public Recipe UpdateRecipe(int recipeId, Recipe newRecipe)
        {
            throw new NotImplementedException();
        }

        public Recipe DeleteRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }



        private static void ValidateRecipe(Recipe recipe)
        {
            if (recipe == null)
            {
                throw new ValidationException("Recipe cannot be empty!");
            }

            if (recipe.Ingredients == null || recipe.Ingredients.Count == 0)
            {
                throw new ValidationException("Recipe does no have any ingredients!");
            }

            if (recipe.Steps == null || recipe.Steps.Count == 0)
            {
                throw new ValidationException("Recipe does no have any steps!");
            }
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bonsai.Domain;

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
        public RecipeService()
        {
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe DeleteRecipe(int recipeId)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe()
        {
            throw new NotImplementedException();
        }

        public RecipeCatalog GetRecipeCatalog()
        {
            throw new NotImplementedException();
        }

        public Recipe UpdateRecipe(int recipeId, Recipe newRecipe)
        {
            throw new NotImplementedException();
        }
    }
}

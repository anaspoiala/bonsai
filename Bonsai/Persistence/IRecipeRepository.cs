using System;
using System.Collections.Generic;
using System.Text;
using Bonsai.Domain;

namespace Bonsai.Persistence
{
    public interface IRecipeRepository
    {
        RecipeCatalog GetRecipeCatalogOfCurrentAccount();
        Recipe GetRecipe(long recipeId);
        Recipe AddRecipe(Recipe recipe);
        Recipe DeleteRecipe(long recipeId);
        Recipe UpdateRecipe(long recipeId, Recipe recipe);
    }
}

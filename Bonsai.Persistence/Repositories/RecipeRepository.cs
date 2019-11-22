using System;
using Bonsai.Domain;
using Bonsai.Helpers;
using Bonsai.Persistence.Context;

namespace Bonsai.Persistence.Repositories
{
    public class RecipeRepository : IRecipeRepository
    {
        private PantryDbContext context;
        private UserInformation userInformation;

        public RecipeRepository(PantryDbContext context, UserInformation userInformation)
        {
            this.context = context;
            this.userInformation = userInformation;
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe DeleteRecipe(long recipeId)
        {
            throw new NotImplementedException();
        }

        public Recipe GetRecipe(long recipeId)
        {
            throw new NotImplementedException();
        }

        public RecipeCatalog GetRecipeCatalogOfCurrentAccount()
        {
            throw new NotImplementedException();
        }

        public Recipe UpdateRecipe(long recipeId, Recipe recipe)
        {
            throw new NotImplementedException();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Bonsai.Domain;
using Bonsai.Exceptions;
using Bonsai.Helpers;
using Bonsai.Persistence.Context;
using Bonsai.Persistence.Helpers;
using Microsoft.EntityFrameworkCore;
using DB = Bonsai.Persistence.Model;

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


        public RecipeCatalog GetRecipeCatalogOfCurrentAccount()
        {
            var dbRecipeCatalog = GetDbRecipeCatalogOfCurrentAccount();
            var recipeCatalog = EntityMapper.ToDomainModel(dbRecipeCatalog);

            return recipeCatalog;
        }

        public Recipe GetRecipe(long recipeId)
        {
            throw new NotImplementedException();
        }

        public Recipe AddRecipe(Recipe recipe)
        {
            var dbRecipeCatalog = GetDbRecipeCatalogOfCurrentAccount();
            var dbRecipe = EntityMapper.ToDatabaseModel(recipe);

            dbRecipeCatalog.Recipes.Add(dbRecipe);
            context.Recipes.Add(dbRecipe);

            context.SaveChanges();

            return EntityMapper.ToDomainModel(dbRecipe);
        }

        public Recipe UpdateRecipe(long recipeId, Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Recipe DeleteRecipe(long recipeId)
        {
            throw new NotImplementedException();
        }



        private DB.Recipes.RecipeCatalog GetDbRecipeCatalogOfCurrentAccount()
        {
            var dbRecipeCatalog = context.RecipeCatalogs
                .Include(recipeCatalog => recipeCatalog.Recipes)
                    .ThenInclude(recipe => recipe.RecipeItems)
                        .ThenInclude(itemInThisRecipe => itemInThisRecipe.Item)
                .SingleOrDefault(recipeCatalog => recipeCatalog.UserData.Account.Id == userInformation.CurrentUserId);

            if (dbRecipeCatalog == null)
            {
                throw new RecipeCatalogNotFoundException();
            }

            foreach (var recipe in dbRecipeCatalog.Recipes)
            {
                context.Entry(recipe).Collection(r => r.RecipeItems).Load();
            }

            return dbRecipeCatalog;
        }

        private List<DB.Items.Item> GetDbItemsOfRecipe(DB.Recipes.Recipe recipe)
        {
            return recipe.RecipeItems.Select(recipeItem => recipeItem.Item).ToList();
        }


    }
}

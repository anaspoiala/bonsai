using System.Collections.Generic;
using System.Linq;
using Database = Bonsai.Persistence.Model;

namespace Bonsai.Persistence.Helpers
{
    public static class EntityMapper
    {

        #region Account and User Data Related Mapping

        // ==================================== User Account ====================================

        public static Domain.UserAccount ToDomainModel(Database.Accounts.UserAccount db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.UserAccount
            {
                Id = db.Id,
                Username = db.Username,
                Email = db.Email,
                UserData = ToDomainModel(db.UserData)
            };
        }

        public static Database.Accounts.UserAccount ToDatabaseModel(Domain.UserAccount d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Accounts.UserAccount
            {
                Id = d.Id,
                Username = d.Username,
                Email = d.Email,
                UserData = ToDatabaseModel(d.UserData)
            };
        }

        // ==================================== User Data ====================================

        public static Domain.UserData ToDomainModel(Database.Accounts.UserData db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.UserData
            {
                Id = db.Id,
                FirstName = db.FirstName,
                LastName = db.LastName,
                DateOfBirth = db.DateOfBirth,
                Gender = db.Gender,
                Pantry = ToDomainModel(db.Pantry),
                RecipeCatalog = ToDomainModel(db.RecipeCatalog),
                MealPlanCalendar = ToDomainModel(db.MealPlanCalendar),
                Tags = db.Tags?.Select(tag => ToDomainModel(tag))?.ToList() ?? null
            };
        }

        public static Database.Accounts.UserData ToDatabaseModel(Domain.UserData d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Accounts.UserData
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DateOfBirth = d.DateOfBirth,
                Gender = d.Gender,
                Pantry = ToDatabaseModel(d.Pantry),
                RecipeCatalog = ToDatabaseModel(d.RecipeCatalog),
                MealPlanCalendar = ToDatabaseModel(d.MealPlanCalendar),
                Tags = d.Tags?.Select(tag => ToDatabaseModel(tag))?.ToList() ?? null
            };
        }

        #endregion

        #region Pantry and Items Related Mapping

        // ==================================== Pantry ====================================

        public static Domain.Pantry ToDomainModel(Database.Items.Pantry db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.Pantry
            {
                Id = db.Id,
                Items = db.Items?.Select(i => ToDomainModel(i))?.ToList() ?? null
            };
        }

        public static Database.Items.Pantry ToDatabaseModel(Domain.Pantry d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Items.Pantry
            {
                Id = d.Id,
                Items = d.Items?.Select(i => ToDatabaseModel(i))?.ToList() ?? null
            };
        }

        // ==================================== Item ====================================

        public static Domain.Item ToDomainModel(Database.Items.Item db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.Item
            {
                Id = db.Id,
                Name = db.Name,
                Tags = db.Tags?.Select(tag => ToDomainModel(tag.Tag))?.ToList() ?? null
            };
        }

        public static Database.Items.Item ToDatabaseModel(Domain.Item d)
        {
            if (d == null)
            {
                return null;
            }

            var db = new Database.Items.Item
            {
                Id = d.Id,
                Name = d.Name,
                RecipeItems = new List<Database.Items.RecipeItem>(),
                PantryItems = new List<Database.Items.PantryItem>()
            };

            db.Tags = d.Tags?.Select(tag => new Database.Tagging.ItemTag
            {
                Tag = ToDatabaseModel(tag),
                Item = db
            })?.ToList() ?? null;

            return db;
        }

        // ==================================== Pantry Item ====================================

        public static Domain.PantryItem ToDomainModel(Database.Items.PantryItem db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.PantryItem
            {
                Id = db.Id,
                Item = ToDomainModel(db.Item),
                Quantity = db.Quantity,
                BuyDate = db.BuyDate,
                ExpirationDate = db.ExpirationDate,
                Tags = db.Tags?.Select(tag => ToDomainModel(tag.Tag))?.ToList() ?? null
            };
        }

        public static Database.Items.PantryItem ToDatabaseModel(Domain.PantryItem d)
        {
            if (d == null)
            {
                return null;
            }

            var db = new Database.Items.PantryItem
            {
                Id = d.Id,
                Item = ToDatabaseModel(d.Item),
                Quantity = d.Quantity,
                BuyDate = d.BuyDate,
                ExpirationDate = d.ExpirationDate,
            };

            db.Tags = d.Tags?.Select(tag => new Database.Tagging.PantryItemTag
            {
                Tag = ToDatabaseModel(tag),
                PantryItem = db
            })?.ToList() ?? null;

            return db;
        }

        // ==================================== Recipe Item ====================================

        public static Domain.RecipeItem ToDomainModel(Database.Items.RecipeItem db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.RecipeItem
            {
                Id = db.Id,
                Item = ToDomainModel(db.Item),
                RequiredQuantity = db.RequiredQuantity,
                Adjectives = db.Adjectives
            };
        }

        public static Database.Items.RecipeItem ToDatabaseModel(Domain.RecipeItem d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Items.RecipeItem
            {
                Id = d.Id,
                RequiredQuantity = d.RequiredQuantity,
                Adjectives = d.Adjectives,
                Item = ToDatabaseModel(d.Item)
            };
        }

        #endregion

        #region Recipe Related Mappings

        // ==================================== Recipe Catalog ====================================

        public static Domain.RecipeCatalog ToDomainModel(Database.Recipes.RecipeCatalog db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.RecipeCatalog
            {
                Id = db.Id,
                Recipes = db.Recipes?.Select(r => ToDomainModel(r))?.ToList() ?? null
            };
        }

        public static Database.Recipes.RecipeCatalog ToDatabaseModel(Domain.RecipeCatalog d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Recipes.RecipeCatalog
            {
                Id = d.Id,
                Recipes = d.Recipes?.Select(r => ToDatabaseModel(r))?.ToList() ?? null
            };
        }

        // ==================================== Recipe ====================================

        public static Domain.Recipe ToDomainModel(Database.Recipes.Recipe db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.Recipe
            {
                Id = db.Id,
                Name = db.Name,
                Steps = db.Steps,
                Ingredients = db.RecipeItems?
                     .Select(recipeItem => ToDomainModel(recipeItem))?
                     .ToList() ?? null,
                Tags = db.Tags?
                     .Select(recipeTag => ToDomainModel(recipeTag.Tag))?
                     .ToList() ?? null
            };
        }

        public static Database.Recipes.Recipe ToDatabaseModel(Domain.Recipe d)
        {
            if (d == null)
            {
                return null;
            }

            var db = new Database.Recipes.Recipe
            {
                Id = d.Id,
                Name = d.Name,
                Steps = d.Steps,
                PlannedRecipes = new List<Database.Recipes.PlannedRecipe>()
            };

            db.RecipeItems = d.Ingredients?.Select(ingredient => new Database.Items.RecipeItem
            {
                Item = ToDatabaseModel(ingredient.Item),
                Recipe = db
            })?.ToList() ?? null;

            db.Tags = d.Tags?.Select(tag => new Database.Tagging.RecipeTag
            {
                Tag = ToDatabaseModel(tag),
                Recipe = db
            })?.ToList() ?? null;

            return db;
        }

        // ==================================== Planned Recipe ====================================

        public static Domain.PlannedRecipe ToDomainModel(Database.Recipes.PlannedRecipe db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.PlannedRecipe
            {
                Id = db.Id,
                Recipe = ToDomainModel(db.Recipe),
                PlannedDate = db.PlannedDate,
                PlannedTime = db.PlannedTime
            };
        }

        public static Database.Recipes.PlannedRecipe ToDatabaseModel(Domain.PlannedRecipe d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Recipes.PlannedRecipe
            {
                Id = d.Id,
                Recipe = ToDatabaseModel(d.Recipe),
                PlannedDate = d.PlannedDate,
                PlannedTime = d.PlannedTime
            };
        }

        #endregion

        #region Meal Plan Related Mappings

        // ==================================== Meal Plan Calendar ====================================

        public static Domain.MealPlanCalendar ToDomainModel(Database.MealPlans.MealPlanCalendar db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.MealPlanCalendar
            {
                Id = db.Id,
                MealPlans = db.MealPlans?.Select(mp => ToDomainModel(mp))?.ToList() ?? null
            };
        }

        public static Database.MealPlans.MealPlanCalendar ToDatabaseModel(Domain.MealPlanCalendar d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.MealPlans.MealPlanCalendar
            {
                Id = d.Id,
                MealPlans = d.MealPlans?.Select(mp => ToDatabaseModel(mp))?.ToList() ?? null
            };
        }

        // ==================================== Meal Plan ====================================

        public static Domain.MealPlan ToDomainModel(Database.MealPlans.MealPlan db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.MealPlan
            {
                Id = db.Id,
                Name = db.Name,
                DateFrom = db.DateFrom,
                DateTo = db.DateTo,
                PlannedRecipes = db.PlannedRecipes?
                    .Select(plannedRecipe => ToDomainModel(plannedRecipe))?
                    .ToList() ?? null
            };
        }

        public static Database.MealPlans.MealPlan ToDatabaseModel(Domain.MealPlan d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.MealPlans.MealPlan
            {
                Id = d.Id,
                Name = d.Name,
                DateFrom = d.DateFrom,
                DateTo = d.DateTo,
                PlannedRecipes = d.PlannedRecipes?
                    .Select(plannedRecipe => ToDatabaseModel(plannedRecipe))?
                    .ToList() ?? null
            };
        }

        #endregion

        #region Tagging Related Mappings

        // ==================================== Tag ====================================

        public static Domain.Tag ToDomainModel(Database.Tagging.Tag db)
        {
            if (db == null)
            {
                return null;
            }

            return new Domain.Tag
            {
                Id = db.Id,
                Name = db.Name,
                Description = db.Description
            };
        }

        public static Database.Tagging.Tag ToDatabaseModel(Domain.Tag d)
        {
            if (d == null)
            {
                return null;
            }

            return new Database.Tagging.Tag
            {
                Id = d.Id,
                Name = d.Name,
                Description = d.Description,
                ItemTags = new List<Database.Tagging.ItemTag>(),
                PantryItemTags = new List<Database.Tagging.PantryItemTag>(),
                RecipeTags = new List<Database.Tagging.RecipeTag>()
            };
        }

        #endregion

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Database = Bonsai.Persistence.Model;
using Domain = Bonsai.Domain;

namespace Bonsai.Persistence
{
    public static class EntityMapper
    {
        public static Domain.UserAccount ToDomainModel(Database.UserAccount db)
        {
            return new Domain.UserAccount
            {
                Id = db.Id,
                Username = db.Username,
                Email= db.Email,
                UserData = ToDomainModel(db.UserData)
            };
        }

        public static Database.UserAccount ToDatabaseModel(Domain.UserAccount d)
        {
            return new Database.UserAccount
            {
                Id = d.Id,
                Username = d.Username,
                Email = d.Email,
                UserData = ToDatabaseModel(d.UserData)
            };
        }

        public static Domain.UserData ToDomainModel(Database.UserData db)
        {
            return new Domain.UserData
            {
                Id = db.Id,
                FirstName = db.FirstName,
                LastName = db.LastName,
                DateOfBirth = db.DateOfBirth,
                Gender = db.Gender,
                Pantry = ToDomainModel(db.Pantry),
                RecipeCatalog = ToDomainModel(db.RecipeCatalog),
                MealPlanHistory = ToDomainModel(db.MealPlanHistory)
            };
        }

        public static Database.UserData ToDatabaseModel(Domain.UserData d)
        {
            return new Database.UserData
            {
                Id = d.Id,
                FirstName = d.FirstName,
                LastName = d.LastName,
                DateOfBirth = d.DateOfBirth,
                Gender = d.Gender,
                Pantry = ToDatabaseModel(d.Pantry),
                RecipeCatalog = ToDatabaseModel(d.RecipeCatalog),
                MealPlanHistory = ToDatabaseModel(d.MealPlanHistory)
            };
        }

        public static Domain.Pantry ToDomainModel(Database.Pantry db)
        {
            return new Domain.Pantry
            {
                Id = db.Id,
                Items = db.Items.Select(i => ToDomainModel(i)).ToList()
            };
        }

        public static Database.Pantry ToDatabaseModel(Domain.Pantry d)
        {
            return new Database.Pantry
            {
                Id = d.Id,
                Items = d.Items.Select(i => ToDatabaseModel(i)).ToList()
            };
        }

        public static Domain.RecipeCatalog ToDomainModel(Database.RecipeCatalog db)
        {
            return new Domain.RecipeCatalog
            {
                Id = db.Id,
                Recipes = db.Recipes.Select(r => ToDomainModel(r)).ToList()
            };
        }

        public static Database.RecipeCatalog ToDatabaseModel(Domain.RecipeCatalog d)
        {
            return new Database.RecipeCatalog
            {
                Id = d.Id,
                Recipes = d.Recipes.Select(r => ToDatabaseModel(r)).ToList()
            };
        }

        public static Domain.MealPlanHistory ToDomainModel(Database.MealPlanHistory db)
        {
            return new Domain.MealPlanHistory
            {
                Id = db.Id,
                MealPlans = db.MealPlans.Select(mp => ToDomainModel(mp)).ToList()
            };
        }

        public static Database.MealPlanHistory ToDatabaseModel(Domain.MealPlanHistory d)
        {
            return new Database.MealPlanHistory
            {
                Id = d.Id,
                MealPlans = d.MealPlans.Select(mp => ToDatabaseModel(mp)).ToList()
            };
        }

        public static Domain.Item ToDomainModel(Database.Item db)
        {
            return new Domain.Item
            {
                Id = db.Id,
                Name = db.Name,
                Quantity = db.Quantity,
                BuyDate = db.BuyDate,
                ExpirationDate = db.ExpirationDate
            };
        }

        public static Database.Item ToDatabaseModel(Domain.Item d)
        {
            return new Database.Item
            {
                Id = d.Id,
                Name = d.Name,
                Quantity = d.Quantity,
                BuyDate = d.BuyDate,
                ExpirationDate = d.ExpirationDate
            };
        }

        public static Domain.MealPlan ToDomainModel(Database.MealPlan db)
        {
            return new Domain.MealPlan
            {
                Id = db.Id,
                Name = db.Name,
                DateFrom = db.DateFrom,
                DateTo = db.DateTo,
                PlannedRecipes = db.PlannedRecipes.Select(pr => ToDomainModel(pr)).ToList()
            };
        }

        public static Database.MealPlan ToDatabaseModel(Domain.MealPlan d)
        {
            return new Database.MealPlan
            {
                Id = d.Id,
                Name = d.Name,
                DateFrom = d.DateFrom,
                DateTo = d.DateTo,
                PlannedRecipes = d.PlannedRecipes.Select(pr => ToDatabaseModel(pr)).ToList()
            };
        }

        public static Domain.PlannedRecipe ToDomainModel(Database.PlannedRecipe db)
        {
            return new Domain.PlannedRecipe
            {
                Id = db.Id,
                Recipe = ToDomainModel(db.Recipe),
                PlannedDate = db.PlannedDate,
                PlannedTime = db.PlannedTime
            };
        }

        public static Database.PlannedRecipe ToDatabaseModel(Domain.PlannedRecipe d)
        {
            return new Database.PlannedRecipe
            {
                Id = d.Id,
                Recipe = ToDatabaseModel(d.Recipe),
                PlannedDate = d.PlannedDate,
                PlannedTime = d .PlannedTime
            };
        }

        public static Domain.Recipe ToDomainModel(Database.Recipe db)
        {
            return new Domain.Recipe
            {
                Id = db.Id,
                Name = db.Name,
                Steps = db.Steps
            };
        }

        public static Database.Recipe ToDatabaseModel(Domain.Recipe d)
        {
            return new Database.Recipe
            {
                Id = d.Id,
                Name = d.Name,
                Steps = d.Steps
            };
        }

    }
}

using System;
using System.Linq;
using Bonsai.Domain.Enums;
using Bonsai.Persistence.Model.Accounts;
using Bonsai.Persistence.Model.Items;
using Bonsai.Persistence.Model.MealPlans;
using Bonsai.Persistence.Model.Recipes;
using Bonsai.Persistence.Model.Tagging;
using Microsoft.EntityFrameworkCore;

namespace Bonsai.Persistence.Context
{
    public class PantryDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserData> UsersData { get; set; }

        public DbSet<Pantry> Pantries { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<PantryItem> PantryItems { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }

        public DbSet<RecipeCatalog> RecipeCatalogs { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<PlannedRecipe> PlannedRecipes { get; set; }

        public DbSet<MealPlanCalendar> MealPlanCalendars { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<ItemTag> ItemTags { get; set; }
        public DbSet<PantryItemTag> PantryItemTags { get; set; }
        public DbSet<RecipeTag> RecipeTags { get; set; }


        private static readonly string SEPARATOR = "|||";


        public PantryDbContext(DbContextOptions<PantryDbContext> options)
            : base(options) { }


        protected override void OnModelCreating(ModelBuilder model)
        {
            SetupOneToOneRelations(model);
            SetupOneToManyRelations(model);
            SetupManyToManyRelations(model);
            SetupConversions(model);
        }

        private void SetupOneToOneRelations(ModelBuilder model)
        {
            // One UserAccount has one UserData.
            model.Entity<UserAccount>()
                .HasOne(userAccount => userAccount.UserData)
                .WithOne(userData => userData.Account)
                .HasForeignKey<UserData>(userData => userData.AccountId);

            // One UserData has one Pantry.
            model.Entity<UserData>()
                .HasOne(userData => userData.Pantry)
                .WithOne(pantry => pantry.UserData)
                .HasForeignKey<Pantry>(pantry => pantry.UserDataId);

            // One UserData has one RecipeCatalog.
            model.Entity<UserData>()
                .HasOne(userData => userData.RecipeCatalog)
                .WithOne(recipeCatalog => recipeCatalog.UserData)
                .HasForeignKey<RecipeCatalog>(recipeCatalog => recipeCatalog.UserDataId);

            // One UserData has one MealPlanCalendar.
            model.Entity<UserData>()
                .HasOne(userData => userData.MealPlanCalendar)
                .WithOne(mealPlanCalendar => mealPlanCalendar.UserData)
                .HasForeignKey<MealPlanCalendar>(mealPlanCalendar => mealPlanCalendar.UserDataId);
        }

        private void SetupOneToManyRelations(ModelBuilder model)
        {
            // One PantryItem has only one Item, but one Item exist in many PantryItems.
            model.Entity<PantryItem>()
                 .HasOne(pantryItem => pantryItem.Item)
                 .WithMany(i => i.PantryItems);

            // One UserData can own many Tags, but one Tag belongs to only one UserData.
            model.Entity<UserData>()
                .HasMany(userData => userData.Tags)
                .WithOne(tag => tag.UserData);
        }

        private void SetupManyToManyRelations(ModelBuilder model)
        {
            // One Item is used in many Recipes and one Recipe has many Items.
            model.Entity<RecipeItem>()
                .HasKey(recipeItem
                    //=> new {recipeItem.Id, recipeItem.RecipeId, recipeItem.ItemId });
                    //=> new { recipeItem.RecipeId, recipeItem.ItemId });
                    => new { recipeItem.Id });
            model.Entity<RecipeItem>()
                .HasOne(recipeItem => recipeItem.Recipe)
                .WithMany(recipe => recipe.RecipeItems)
                .HasForeignKey(recipe => recipe.RecipeId);
            model.Entity<RecipeItem>()
                .HasOne(recipeItem => recipeItem.Item)
                .WithMany(item => item.RecipeItems)
                .HasForeignKey(recipeItem => recipeItem.ItemId);

            // One Recipe is used in many MealPlans and one MealPlan has many Recipes.
            model.Entity<PlannedRecipe>()
                .HasKey(plannedRecipe
                    //=> new { plannedRecipe.Id, plannedRecipe.RecipeId, plannedRecipe.MealPlanId });
                    //=> new { plannedRecipe.RecipeId, plannedRecipe.MealPlanId });
                    => new { plannedRecipe.Id });
            model.Entity<PlannedRecipe>()
                .HasOne(plannedRecipe => plannedRecipe.Recipe)
                .WithMany(recipe => recipe.PlannedRecipes)
                .HasForeignKey(recipe => recipe.RecipeId);
            model.Entity<PlannedRecipe>()
                .HasOne(plannedRecipe => plannedRecipe.MealPlan)
                .WithMany(mealPlan => mealPlan.PlannedRecipes)
                .HasForeignKey(mealPlan => mealPlan.MealPlanId);

            // One Tag is used for many Items and one Item has many Tags.
            model.Entity<ItemTag>()
                .HasKey(itemTag => new { itemTag.TagId, itemTag.ItemId });
            model.Entity<ItemTag>()
                .HasOne(itemTag => itemTag.Tag)
                .WithMany(tag => tag.ItemTags)
                .HasForeignKey(tag => tag.TagId);
            model.Entity<ItemTag>()
                .HasOne(itemTag => itemTag.Item)
                .WithMany(item => item.Tags)
                .HasForeignKey(item => item.ItemId);

            // One Tag is used for many PantryItems and one PantryItem has many Tags.
            model.Entity<PantryItemTag>()
                .HasKey(pantryItemTag => new { pantryItemTag.TagId, pantryItemTag.PantryItemId });
            model.Entity<PantryItemTag>()
                .HasOne(pantryItemTag => pantryItemTag.Tag)
                .WithMany(tag => tag.PantryItemTags)
                .HasForeignKey(tag => tag.TagId);
            model.Entity<PantryItemTag>()
                .HasOne(pantryItemTag => pantryItemTag.PantryItem)
                .WithMany(pantryItem => pantryItem.Tags)
                .HasForeignKey(pantryItem => pantryItem.PantryItemId);

            // One Tag is used for many Recipes and one Recipe has many Tags.
            model.Entity<RecipeTag>()
                .HasKey(recipeTag => new { recipeTag.TagId, recipeTag.RecipeId });
            model.Entity<RecipeTag>()
                .HasOne(recipeTag => recipeTag.Tag)
                .WithMany(tag => tag.RecipeTags)
                .HasForeignKey(tag => tag.TagId);
            model.Entity<RecipeTag>()
                .HasOne(recipeTag => recipeTag.Recipe)
                .WithMany(recipe => recipe.Tags)
                .HasForeignKey(pantryItem => pantryItem.RecipeId);
        }

        private void SetupConversions(ModelBuilder model)
        {
            // Quantity is part of PantryItem and RecipeItem. It is represented with 2 columns: "Amount" and "Unit"
            model.Entity<PantryItem>(pantryItem =>
            {
                pantryItem.OwnsOne(pi => pi.Quantity, quantity =>
                {
                    quantity.Property(q => q.Amount).HasColumnName("Amount");
                    quantity.Property(q => q.Unit).HasColumnName("Unit");
                });
            });

            model.Entity<RecipeItem>(recipeItem =>
            {
                recipeItem.OwnsOne(ri => ri.RequiredQuantity, quantity =>
                {
                    quantity.Property(q => q.Amount).HasColumnName("RequiredAmount");
                    quantity.Property(q => q.Unit).HasColumnName("Unit");
                });
            });

            // TimeOfDay will be converted to a string representing the enum value, rather than an integer.
            model.Entity<PlannedRecipe>()
                .Property(plannedRecipe => plannedRecipe.PlannedTime)
                .HasConversion(
                    plannedTime => plannedTime.ToString(),
                    plannedTime => (TimeOfDay)Enum.Parse(typeof(TimeOfDay), plannedTime));

            // Recipe steps are joined into a single string separated with a separator.
            model.Entity<Recipe>()
                .Property(recipe => recipe.Steps)
                .HasColumnName("Steps")
                .HasColumnType("varchar(1000)")
                .HasConversion(
                    steps => string.Join(SEPARATOR, steps),
                    steps => steps
                        .Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                );

            // RecipiItem adjectives are joined into a single comma-separated string.
            model.Entity<RecipeItem>()
                .Property(recipeItem => recipeItem.Adjectives)
                .HasColumnName("Adjectives")
                .HasColumnType("varchar(128)")
                .HasConversion(
                    adjectives => string.Join(";", adjectives),
                    adjectives => adjectives
                        .Split(";", StringSplitOptions.RemoveEmptyEntries)
                        .ToList()
                );
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Bonsai.Domain.Enums;
using Bonsai.Persistence.Model;

namespace Bonsai.Persistence.Context
{
    public class PantryDbContext : DbContext
    {
        public DbSet<UserAccount> UserAccounts { get; set; }
        public DbSet<UserData> UsersData { get; set; }
        public DbSet<Pantry> Pantries { get; set; }
        public DbSet<MealPlanCalendar> MealPlanCalendars { get; set; }
        public DbSet<RecipeCatalog> RecipeCatalogs { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Recipe> Recipes { get; set; }
        public DbSet<RecipeItem> RecipeItems { get; set; }
        public DbSet<PlannedRecipe> PlannedRecipes { get; set; }
        public DbSet<MealPlan> MealPlans { get; set; }

        private static readonly string SEPARATOR = "|||";

        public PantryDbContext(DbContextOptions<PantryDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder model)
        {
            // One-To-One Relations

            model.Entity<UserAccount>()
                .HasOne(a => a.UserData)
                .WithOne(d => d.Account)
                .HasForeignKey<UserData>(d => d.AccountId);

            model.Entity<UserData>()
                .HasOne(d => d.Pantry)
                .WithOne(p => p.UserData)
                .HasForeignKey<Pantry>(p => p.UserDataId);

            model.Entity<UserData>()
                .HasOne(d => d.RecipeCatalog)
                .WithOne(rc => rc.UserData)
                .HasForeignKey<RecipeCatalog>(rc => rc.UserDataId);

            model.Entity<UserData>()
                .HasOne(d => d.MealPlanCalendar)
                .WithOne(mph => mph.UserData)
                .HasForeignKey<MealPlanCalendar>(mph => mph.UserDataId);


            // One-To-Many Relations

            // Many-To-Many Relations

            model.Entity<RecipeItem>()
                .HasKey(ri => new { ri.RecipeId, ri.ItemId });
            model.Entity<RecipeItem>()
                .HasOne(ri => ri.Recipe)
                .WithMany(r => r.ItemsInThisRecipe)
                .HasForeignKey(r => r.RecipeId);
            model.Entity<RecipeItem>()
                .HasOne(ri => ri.Item)
                .WithMany(i => i.RecipesUsingThisItem)
                .HasForeignKey(ri => ri.ItemId);


            // Conversions

            model.Entity<Item>(item =>
            {
                item.OwnsOne(i => i.Quantity, quantity =>
                {
                    quantity.Property(q => q.Amount).HasColumnName("Amount");
                    quantity
                        .Property(q => q.Unit)
                        .HasColumnName("Unit")
                        .HasConversion(
                            unit => unit.ToString(),
                            unit => (MeasurementUnit)Enum.Parse(typeof(MeasurementUnit), unit));
                });
            });

            model.Entity<PlannedRecipe>()
                .Property(pr => pr.PlannedTime)
                .HasConversion(
                    plannedTime => plannedTime.ToString(),
                    plannedTime => (TimeOfDay)Enum.Parse(typeof(TimeOfDay), plannedTime));

            model.Entity<Recipe>()
                .Property(r => r.Steps)
                .HasColumnName("Steps")
                .HasColumnType("varchar(1000)")
                .HasConversion(
                    steps => string.Join(SEPARATOR, steps),
                    steps => steps.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries).ToList());

        }
    }
}

﻿// <auto-generated />
using System;
using Bonsai.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace Bonsai.Migrations
{
    [DbContext(typeof(PantryDbContext))]
    partial class PantryDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.11-servicing-32099")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("Bonsai.Persistence.Model.Accounts.UserAccount", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Email")
                        .IsRequired();

                    b.Property<byte[]>("PasswordHash")
                        .IsRequired();

                    b.Property<byte[]>("PasswordSalt")
                        .IsRequired();

                    b.Property<string>("Username")
                        .IsRequired();

                    b.HasKey("Id");

                    b.ToTable("UserAccounts");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Accounts.UserData", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("AccountId");

                    b.Property<DateTime>("DateOfBirth");

                    b.Property<string>("FirstName");

                    b.Property<string>("Gender");

                    b.Property<string>("LastName");

                    b.HasKey("Id");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("UsersData");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.Item", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("Items");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.Pantry", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserDataId");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId")
                        .IsUnique();

                    b.ToTable("Pantries");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.PantryItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime?>("BuyDate");

                    b.Property<DateTime?>("ExpirationDate");

                    b.Property<long>("ItemId");

                    b.Property<long?>("PantryId");

                    b.HasKey("Id");

                    b.HasIndex("ItemId");

                    b.HasIndex("PantryId");

                    b.ToTable("PantryItems");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.RecipeItem", b =>
                {
                    b.Property<long>("RecipeId");

                    b.Property<long>("ItemId");

                    b.Property<string>("Adjectives")
                        .HasColumnName("Adjectives")
                        .HasColumnType("varchar(128)");

                    b.Property<long>("Id");

                    b.HasKey("RecipeId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("RecipeItems");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.MealPlans.MealPlan", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DateFrom");

                    b.Property<DateTime>("DateTo");

                    b.Property<long?>("MealPlanCalendarId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("MealPlanCalendarId");

                    b.ToTable("MealPlans");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.MealPlans.MealPlanCalendar", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserDataId");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId")
                        .IsUnique();

                    b.ToTable("MealPlanCalendars");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Recipes.PlannedRecipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("MealPlanId");

                    b.Property<DateTime>("PlannedDate");

                    b.Property<string>("PlannedTime")
                        .IsRequired();

                    b.Property<long>("RecipeId");

                    b.HasKey("Id");

                    b.HasIndex("MealPlanId");

                    b.HasIndex("RecipeId");

                    b.ToTable("PlannedRecipes");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Recipes.Recipe", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.Property<long?>("RecipeCatalogId");

                    b.Property<string>("Steps")
                        .HasColumnName("Steps")
                        .HasColumnType("varchar(1000)");

                    b.HasKey("Id");

                    b.HasIndex("RecipeCatalogId");

                    b.ToTable("Recipes");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Recipes.RecipeCatalog", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<long>("UserDataId");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId")
                        .IsUnique();

                    b.ToTable("RecipeCatalogs");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.ItemTag", b =>
                {
                    b.Property<long>("TagId");

                    b.Property<long>("ItemId");

                    b.HasKey("TagId", "ItemId");

                    b.HasIndex("ItemId");

                    b.ToTable("ItemTags");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.PantryItemTag", b =>
                {
                    b.Property<long>("TagId");

                    b.Property<long>("PantryItemId");

                    b.HasKey("TagId", "PantryItemId");

                    b.HasIndex("PantryItemId");

                    b.ToTable("PantryItemTags");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.RecipeTag", b =>
                {
                    b.Property<long>("TagId");

                    b.Property<long>("RecipeId");

                    b.HasKey("TagId", "RecipeId");

                    b.HasIndex("RecipeId");

                    b.ToTable("RecipeTags");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.Tag", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.Property<long>("UserDataId");

                    b.HasKey("Id");

                    b.HasIndex("UserDataId");

                    b.ToTable("Tags");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Accounts.UserData", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Accounts.UserAccount", "Account")
                        .WithOne("UserData")
                        .HasForeignKey("Bonsai.Persistence.Model.Accounts.UserData", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.Pantry", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Accounts.UserData", "UserData")
                        .WithOne("Pantry")
                        .HasForeignKey("Bonsai.Persistence.Model.Items.Pantry", "UserDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.PantryItem", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Items.Item", "Item")
                        .WithMany("PantryItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bonsai.Persistence.Model.Items.Pantry")
                        .WithMany("Items")
                        .HasForeignKey("PantryId");

                    b.OwnsOne("Bonsai.Domain.Quantity", "Quantity", b1 =>
                        {
                            b1.Property<long>("PantryItemId")
                                .ValueGeneratedOnAdd()
                                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                            b1.Property<float>("Amount")
                                .HasColumnName("Amount");

                            b1.Property<string>("Unit")
                                .HasColumnName("Unit");

                            b1.ToTable("PantryItems");

                            b1.HasOne("Bonsai.Persistence.Model.Items.PantryItem")
                                .WithOne("Quantity")
                                .HasForeignKey("Bonsai.Domain.Quantity", "PantryItemId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Items.RecipeItem", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Items.Item", "Item")
                        .WithMany("RecipeItems")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bonsai.Persistence.Model.Recipes.Recipe", "Recipe")
                        .WithMany("RecipeItems")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.OwnsOne("Bonsai.Domain.Quantity", "RequiredQuantity", b1 =>
                        {
                            b1.Property<long>("RecipeItemRecipeId");

                            b1.Property<long>("RecipeItemItemId");

                            b1.Property<float>("Amount")
                                .HasColumnName("RequiredAmount");

                            b1.Property<string>("Unit")
                                .HasColumnName("Unit");

                            b1.ToTable("RecipeItems");

                            b1.HasOne("Bonsai.Persistence.Model.Items.RecipeItem")
                                .WithOne("RequiredQuantity")
                                .HasForeignKey("Bonsai.Domain.Quantity", "RecipeItemRecipeId", "RecipeItemItemId")
                                .OnDelete(DeleteBehavior.Cascade);
                        });
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.MealPlans.MealPlan", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.MealPlans.MealPlanCalendar")
                        .WithMany("MealPlans")
                        .HasForeignKey("MealPlanCalendarId");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.MealPlans.MealPlanCalendar", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Accounts.UserData", "UserData")
                        .WithOne("MealPlanCalendar")
                        .HasForeignKey("Bonsai.Persistence.Model.MealPlans.MealPlanCalendar", "UserDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Recipes.PlannedRecipe", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.MealPlans.MealPlan", "MealPlan")
                        .WithMany("PlannedRecipes")
                        .HasForeignKey("MealPlanId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bonsai.Persistence.Model.Recipes.Recipe", "Recipe")
                        .WithMany("PlannedRecipes")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Recipes.Recipe", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Recipes.RecipeCatalog")
                        .WithMany("Recipes")
                        .HasForeignKey("RecipeCatalogId");
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Recipes.RecipeCatalog", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Accounts.UserData", "UserData")
                        .WithOne("RecipeCatalog")
                        .HasForeignKey("Bonsai.Persistence.Model.Recipes.RecipeCatalog", "UserDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.ItemTag", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Items.Item", "Item")
                        .WithMany("Tags")
                        .HasForeignKey("ItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bonsai.Persistence.Model.Tagging.Tag", "Tag")
                        .WithMany("ItemTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.PantryItemTag", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Items.PantryItem", "PantryItem")
                        .WithMany("Tags")
                        .HasForeignKey("PantryItemId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bonsai.Persistence.Model.Tagging.Tag", "Tag")
                        .WithMany("PantryItemTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.RecipeTag", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Recipes.Recipe", "Recipe")
                        .WithMany("Tags")
                        .HasForeignKey("RecipeId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("Bonsai.Persistence.Model.Tagging.Tag", "Tag")
                        .WithMany("RecipeTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Bonsai.Persistence.Model.Tagging.Tag", b =>
                {
                    b.HasOne("Bonsai.Persistence.Model.Accounts.UserData", "UserData")
                        .WithMany("Tags")
                        .HasForeignKey("UserDataId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}

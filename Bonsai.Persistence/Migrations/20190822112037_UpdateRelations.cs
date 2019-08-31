using Microsoft.EntityFrameworkCore.Migrations;

namespace Bonsai.Migrations
{
    public partial class UpdateRelations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRecipes_MealPlans_MealPlanId",
                table: "PlannedRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRecipes_Recipes_RecipeId",
                table: "PlannedRecipes");

            migrationBuilder.AlterColumn<long>(
                name: "RecipeId",
                table: "PlannedRecipes",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AlterColumn<long>(
                name: "MealPlanId",
                table: "PlannedRecipes",
                nullable: false,
                oldClrType: typeof(long),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRecipes_MealPlans_MealPlanId",
                table: "PlannedRecipes",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRecipes_Recipes_RecipeId",
                table: "PlannedRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRecipes_MealPlans_MealPlanId",
                table: "PlannedRecipes");

            migrationBuilder.DropForeignKey(
                name: "FK_PlannedRecipes_Recipes_RecipeId",
                table: "PlannedRecipes");

            migrationBuilder.AlterColumn<long>(
                name: "RecipeId",
                table: "PlannedRecipes",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AlterColumn<long>(
                name: "MealPlanId",
                table: "PlannedRecipes",
                nullable: true,
                oldClrType: typeof(long));

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRecipes_MealPlans_MealPlanId",
                table: "PlannedRecipes",
                column: "MealPlanId",
                principalTable: "MealPlans",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_PlannedRecipes_Recipes_RecipeId",
                table: "PlannedRecipes",
                column: "RecipeId",
                principalTable: "Recipes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

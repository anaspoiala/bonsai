using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bonsai.Migrations
{
    public partial class RenameMealPlanCalendarAndMadeItemFieldsNullable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_MealPlanHistories_MealPlanHistoryId",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "MealPlanHistoryId",
                table: "MealPlans",
                newName: "MealPlanCalendarId");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlans_MealPlanHistoryId",
                table: "MealPlans",
                newName: "IX_MealPlans_MealPlanCalendarId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Items",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Items",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_MealPlanHistories_MealPlanCalendarId",
                table: "MealPlans",
                column: "MealPlanCalendarId",
                principalTable: "MealPlanHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_MealPlanHistories_MealPlanCalendarId",
                table: "MealPlans");

            migrationBuilder.RenameColumn(
                name: "MealPlanCalendarId",
                table: "MealPlans",
                newName: "MealPlanHistoryId");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlans_MealPlanCalendarId",
                table: "MealPlans",
                newName: "IX_MealPlans_MealPlanHistoryId");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ExpirationDate",
                table: "Items",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "BuyDate",
                table: "Items",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_MealPlanHistories_MealPlanHistoryId",
                table: "MealPlans",
                column: "MealPlanHistoryId",
                principalTable: "MealPlanHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

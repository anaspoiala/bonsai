using Microsoft.EntityFrameworkCore.Migrations;

namespace Bonsai.Migrations
{
    public partial class RenameMealPlanCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanHistories_UsersData_UserDataId",
                table: "MealPlanHistories");

            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_MealPlanHistories_MealPlanCalendarId",
                table: "MealPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlanHistories",
                table: "MealPlanHistories");

            migrationBuilder.RenameTable(
                name: "MealPlanHistories",
                newName: "MealPlanCalendars");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlanHistories_UserDataId",
                table: "MealPlanCalendars",
                newName: "IX_MealPlanCalendars_UserDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlanCalendars",
                table: "MealPlanCalendars",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanCalendars_UsersData_UserDataId",
                table: "MealPlanCalendars",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_MealPlanCalendars_MealPlanCalendarId",
                table: "MealPlans",
                column: "MealPlanCalendarId",
                principalTable: "MealPlanCalendars",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MealPlanCalendars_UsersData_UserDataId",
                table: "MealPlanCalendars");

            migrationBuilder.DropForeignKey(
                name: "FK_MealPlans_MealPlanCalendars_MealPlanCalendarId",
                table: "MealPlans");

            migrationBuilder.DropPrimaryKey(
                name: "PK_MealPlanCalendars",
                table: "MealPlanCalendars");

            migrationBuilder.RenameTable(
                name: "MealPlanCalendars",
                newName: "MealPlanHistories");

            migrationBuilder.RenameIndex(
                name: "IX_MealPlanCalendars_UserDataId",
                table: "MealPlanHistories",
                newName: "IX_MealPlanHistories_UserDataId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_MealPlanHistories",
                table: "MealPlanHistories",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlanHistories_UsersData_UserDataId",
                table: "MealPlanHistories",
                column: "UserDataId",
                principalTable: "UsersData",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_MealPlans_MealPlanHistories_MealPlanCalendarId",
                table: "MealPlans",
                column: "MealPlanCalendarId",
                principalTable: "MealPlanHistories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bonsai.Migrations
{
    public partial class UpdatePasswordStorageMethod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Password",
                table: "UserAccounts");

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordHash",
                table: "UserAccounts",
                nullable: false,
                defaultValue: new byte[] {  });

            migrationBuilder.AddColumn<byte[]>(
                name: "PasswordSalt",
                table: "UserAccounts",
                nullable: false,
                defaultValue: new byte[] {  });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "UserAccounts");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "UserAccounts");

            migrationBuilder.AddColumn<string>(
                name: "Password",
                table: "UserAccounts",
                nullable: false,
                defaultValue: "");
        }
    }
}

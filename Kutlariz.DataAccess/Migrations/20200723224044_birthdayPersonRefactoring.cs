using Microsoft.EntityFrameworkCore.Migrations;

namespace Kutlariz.DataAccess.Migrations
{
    public partial class birthdayPersonRefactoring : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FullName",
                table: "BirthdayPersons");

            migrationBuilder.DropColumn(
                name: "ProfilePicture",
                table: "BirthdayPersons");

            migrationBuilder.AddColumn<string>(
                name: "FirstName",
                table: "BirthdayPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LastName",
                table: "BirthdayPersons",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePictureUrl",
                table: "BirthdayPersons",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FirstName",
                table: "BirthdayPersons");

            migrationBuilder.DropColumn(
                name: "LastName",
                table: "BirthdayPersons");

            migrationBuilder.DropColumn(
                name: "ProfilePictureUrl",
                table: "BirthdayPersons");

            migrationBuilder.AddColumn<string>(
                name: "FullName",
                table: "BirthdayPersons",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ProfilePicture",
                table: "BirthdayPersons",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

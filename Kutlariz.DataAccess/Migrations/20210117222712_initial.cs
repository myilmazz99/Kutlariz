using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kutlariz.DataAccess.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BirthdayPersons",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Birthday = table.Column<DateTime>(nullable: false),
                    ProfilePictureUrl = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BirthdayPersons", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CakeType = table.Column<int>(nullable: false),
                    CakeIngredients = table.Column<string>(nullable: true),
                    Message = table.Column<string>(nullable: true),
                    CakeSize = table.Column<byte>(nullable: false),
                    CakePicture = table.Column<string>(nullable: true),
                    BirthdayPersonName = table.Column<string>(nullable: true),
                    BirthdayPersonProfilePictureUrl = table.Column<string>(nullable: true),
                    AddressDescription = table.Column<string>(nullable: true),
                    Neigborhood = table.Column<string>(nullable: true),
                    State = table.Column<string>(nullable: true),
                    Status = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true),
                    Price = table.Column<double>(nullable: false),
                    PaymentType = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BirthdayPersons");

            migrationBuilder.DropTable(
                name: "Orders");
        }
    }
}

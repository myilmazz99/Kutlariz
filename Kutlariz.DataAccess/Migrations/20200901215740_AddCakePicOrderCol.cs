using Microsoft.EntityFrameworkCore.Migrations;

namespace Kutlariz.DataAccess.Migrations
{
    public partial class AddCakePicOrderCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CakePicture",
                table: "Orders",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CakePicture",
                table: "Orders");
        }
    }
}

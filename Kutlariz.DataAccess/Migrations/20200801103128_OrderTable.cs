using Microsoft.EntityFrameworkCore.Migrations;

namespace Kutlariz.DataAccess.Migrations
{
    public partial class OrderTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                    BirthdayPersonName = table.Column<string>(nullable: true),
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
                name: "Orders");
        }
    }
}

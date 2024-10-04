using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class order : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "TbClientFood",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "TbOrder",
                columns: table => new
                {
                    OrderId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FoodId = table.Column<int>(nullable: false),
                    Image = table.Column<string>(maxLength: 200, nullable: true),
                    FoodName = table.Column<string>(maxLength: 50, nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18, 2)", nullable: false),
                    qty = table.Column<int>(nullable: false),
                    Total = table.Column<decimal>(type: "decimal(18, 2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbOrder", x => x.OrderId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_TbClientFood_OrderId",
                table: "TbClientFood",
                column: "OrderId",
                unique: true,
                filter: "[OrderId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Order",
                table: "TbClientFood",
                column: "OrderId",
                principalTable: "TbOrder",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order",
                table: "TbClientFood");

            migrationBuilder.DropTable(
                name: "TbOrder");

            migrationBuilder.DropIndex(
                name: "IX_TbClientFood_OrderId",
                table: "TbClientFood");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "TbClientFood");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class editTborders : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Order",
                table: "TbClientFood");

            migrationBuilder.DropIndex(
                name: "IX_TbClientFood_OrderId",
                table: "TbClientFood");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "TbClientFood");

            migrationBuilder.AddColumn<int>(
                name: "ClientFoodId",
                table: "TbOrder",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TbOrder_ClientFoodId",
                table: "TbOrder",
                column: "ClientFoodId");

            migrationBuilder.AddForeignKey(
                name: "FK_TbClientFood_TbOrder",
                table: "TbOrder",
                column: "ClientFoodId",
                principalTable: "TbClientFood",
                principalColumn: "ClientFoodId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TbClientFood_TbOrder",
                table: "TbOrder");

            migrationBuilder.DropIndex(
                name: "IX_TbOrder_ClientFoodId",
                table: "TbOrder");

            migrationBuilder.DropColumn(
                name: "ClientFoodId",
                table: "TbOrder");

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "TbClientFood",
                type: "int",
                nullable: true);

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
    }
}

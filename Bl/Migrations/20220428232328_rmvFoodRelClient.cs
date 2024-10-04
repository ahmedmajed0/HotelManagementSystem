using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class rmvFoodRelClient : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
 

          
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbFood");

            migrationBuilder.DropTable(
                name: "TbPayments");

            migrationBuilder.DropTable(
                name: "TbRoomReservations");

            migrationBuilder.DropTable(
                name: "TbSupplierGoods");

            migrationBuilder.DropTable(
                name: "TbFoodCategory");

            migrationBuilder.DropTable(
                name: "TbClientFood");

            migrationBuilder.DropTable(
                name: "TbReservations");

            migrationBuilder.DropTable(
                name: "TbRooms");

            migrationBuilder.DropTable(
                name: "TbSuppliers");

            migrationBuilder.DropTable(
                name: "TbClients");

            migrationBuilder.DropTable(
                name: "TbMeels");

            migrationBuilder.DropTable(
                name: "TbEmployees");

            migrationBuilder.DropTable(
                name: "TbViews");
        }
    }
}

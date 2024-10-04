using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class editTbcliet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Qty",
                table: "TbClientFood");

            migrationBuilder.DropColumn(
                name: "RoomFloor",
                table: "TbClientFood");

            migrationBuilder.AddColumn<string>(
                name: "GuestPhone",
                table: "TbClientFood",
                nullable: false);

            migrationBuilder.AddColumn<int>(
                name: "RecievingHour",
                table: "TbClientFood",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RecievingMinutes",
                table: "TbClientFood",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GuestPhone",
                table: "TbClientFood");

            migrationBuilder.DropColumn(
                name: "RecievingHour",
                table: "TbClientFood");

            migrationBuilder.DropColumn(
                name: "RecievingMinutes",
                table: "TbClientFood");

            migrationBuilder.AddColumn<byte>(
                name: "Qty",
                table: "TbClientFood",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);

            migrationBuilder.AddColumn<byte>(
                name: "RoomFloor",
                table: "TbClientFood",
                type: "tinyint",
                nullable: false,
                defaultValue: (byte)0);
        }
    }
}

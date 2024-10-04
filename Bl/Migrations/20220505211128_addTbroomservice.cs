using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class addTbroomservice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.CreateTable(
                name: "TbRoomService",
                columns: table => new
                {
                    RoomServiceId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomNo = table.Column<int>(nullable: false),
                    CleaningDate = table.Column<DateTime>(type: "date", nullable: false),
                    RecievingHour = table.Column<int>(nullable: false),
                    RecievingMinutes = table.Column<int>(nullable: false),
                    PM = table.Column<string>(maxLength: 3, nullable: true),
                    Status = table.Column<string>(maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TbRoomService", x => x.RoomServiceId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "TbRoomService");

            migrationBuilder.DropColumn(
                name: "PM",
                table: "TbClientFood");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "TbClientFood");

            migrationBuilder.AlterColumn<string>(
                name: "GuestPhone",
                table: "TbClientFood",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 11);
        }
    }
}

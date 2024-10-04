using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class roompass : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "RoomPassword",
                table: "TbRooms",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoomPassword",
                table: "TbRooms");
        }
    }
}

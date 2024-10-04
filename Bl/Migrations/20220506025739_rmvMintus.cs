using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Bl.Migrations
{
    public partial class rmvMintus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {


            migrationBuilder.DropColumn(
                name: "RecievingMinutes",
                table: "TbRoomService");




        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CleaningDay",
                table: "TbRoomService");

            migrationBuilder.AlterColumn<string>(
                name: "PM",
                table: "TbRoomService",
                type: "nvarchar(3)",
                maxLength: 3,
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 3);

            migrationBuilder.AddColumn<DateTime>(
                name: "CleaningDate",
                table: "TbRoomService",
                type: "date",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<int>(
                name: "RecievingMinutes",
                table: "TbRoomService",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class tim : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "AddedDAte",
                table: "MyProfileForAgents",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedDAte",
                table: "MyProfileForAgents");
        }
    }
}

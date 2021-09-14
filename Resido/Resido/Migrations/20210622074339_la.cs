using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class la : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProfileForAgentsId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Properties_MyProfileForAgentsId",
                table: "Properties",
                column: "MyProfileForAgentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_MyProfileForAgents_MyProfileForAgentsId",
                table: "Properties",
                column: "MyProfileForAgentsId",
                principalTable: "MyProfileForAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_MyProfileForAgents_MyProfileForAgentsId",
                table: "Properties");

            migrationBuilder.DropIndex(
                name: "IX_Properties_MyProfileForAgentsId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "MyProfileForAgentsId",
                table: "Properties");
        }
    }
}

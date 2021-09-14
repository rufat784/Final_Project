using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class subscribed22 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Subscribes_MyProfileForAgents_MyProfileForAgentsId",
                table: "Subscribes");

            migrationBuilder.DropIndex(
                name: "IX_Subscribes_MyProfileForAgentsId",
                table: "Subscribes");

            migrationBuilder.DropColumn(
                name: "MyProfileForAgentsId",
                table: "Subscribes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MyProfileForAgentsId",
                table: "Subscribes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Subscribes_MyProfileForAgentsId",
                table: "Subscribes",
                column: "MyProfileForAgentsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Subscribes_MyProfileForAgents_MyProfileForAgentsId",
                table: "Subscribes",
                column: "MyProfileForAgentsId",
                principalTable: "MyProfileForAgents",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

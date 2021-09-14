using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class again : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProfileForAgents_RegistrationOptionSelects_RegistrationOptionSelectId",
                table: "MyProfileForAgents");

            migrationBuilder.DropColumn(
                name: "Color",
                table: "MyProfileForAgents");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationOptionSelectId",
                table: "MyProfileForAgents",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProfileForAgents_RegistrationOptionSelects_RegistrationOptionSelectId",
                table: "MyProfileForAgents",
                column: "RegistrationOptionSelectId",
                principalTable: "RegistrationOptionSelects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MyProfileForAgents_RegistrationOptionSelects_RegistrationOptionSelectId",
                table: "MyProfileForAgents");

            migrationBuilder.AlterColumn<int>(
                name: "RegistrationOptionSelectId",
                table: "MyProfileForAgents",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "MyProfileForAgents",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_MyProfileForAgents_RegistrationOptionSelects_RegistrationOptionSelectId",
                table: "MyProfileForAgents",
                column: "RegistrationOptionSelectId",
                principalTable: "RegistrationOptionSelects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

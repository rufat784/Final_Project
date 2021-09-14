using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class foreignkeynull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyStatusId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties",
                column: "PropertyStatusId",
                principalTable: "PropertyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyStatusId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties",
                column: "PropertyStatusId",
                principalTable: "PropertyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

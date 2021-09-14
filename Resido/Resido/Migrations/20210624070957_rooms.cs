using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class rooms : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoomsCountId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "RoomsCounts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CountName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomsCounts", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Properties_RoomsCountId",
                table: "Properties",
                column: "RoomsCountId");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_RoomsCounts_RoomsCountId",
                table: "Properties",
                column: "RoomsCountId",
                principalTable: "RoomsCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_RoomsCounts_RoomsCountId",
                table: "Properties");

            migrationBuilder.DropTable(
                name: "RoomsCounts");

            migrationBuilder.DropIndex(
                name: "IX_Properties_RoomsCountId",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "RoomsCountId",
                table: "Properties");
        }
    }
}

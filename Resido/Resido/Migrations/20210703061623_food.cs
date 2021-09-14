using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class food : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "SchoolsArounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PropertyId",
                table: "FoodsArounds",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SchoolsArounds_PropertyId",
                table: "SchoolsArounds",
                column: "PropertyId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodsArounds_PropertyId",
                table: "FoodsArounds",
                column: "PropertyId");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodsArounds_Properties_PropertyId",
                table: "FoodsArounds",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SchoolsArounds_Properties_PropertyId",
                table: "SchoolsArounds",
                column: "PropertyId",
                principalTable: "Properties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodsArounds_Properties_PropertyId",
                table: "FoodsArounds");

            migrationBuilder.DropForeignKey(
                name: "FK_SchoolsArounds_Properties_PropertyId",
                table: "SchoolsArounds");

            migrationBuilder.DropIndex(
                name: "IX_SchoolsArounds_PropertyId",
                table: "SchoolsArounds");

            migrationBuilder.DropIndex(
                name: "IX_FoodsArounds_PropertyId",
                table: "FoodsArounds");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "SchoolsArounds");

            migrationBuilder.DropColumn(
                name: "PropertyId",
                table: "FoodsArounds");
        }
    }
}

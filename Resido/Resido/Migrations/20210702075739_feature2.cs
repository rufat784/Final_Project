using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class feature2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Desc",
                table: "OtherFeatures",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Desc",
                table: "OtherFeatures");
        }
    }
}

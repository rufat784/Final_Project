using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class chcek : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CheckBoxOption",
                table: "OtherFeatures");

            migrationBuilder.AddColumn<bool>(
                name: "AirCondition",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Balcony",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Beach",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Bedding",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Dryer",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Heating",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Internet",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Microwave",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Parking",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Smoking",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Supermarket",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "Terrace",
                table: "Properties",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AirCondition",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Balcony",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Beach",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Bedding",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Dryer",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Heating",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Internet",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Microwave",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Parking",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Smoking",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Supermarket",
                table: "Properties");

            migrationBuilder.DropColumn(
                name: "Terrace",
                table: "Properties");

            migrationBuilder.AddColumn<bool>(
                name: "CheckBoxOption",
                table: "OtherFeatures",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}

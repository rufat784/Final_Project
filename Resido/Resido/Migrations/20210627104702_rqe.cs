using Microsoft.EntityFrameworkCore.Migrations;

namespace Resido.Migrations
{
    public partial class rqe : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BathroomCounts_BathroomCountId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BedroomsCounts_BedroomsCountId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuildingAges_BuildingAgeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_CityOfProperties_CityOfPropertyId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_GarageCounts_GarageCountId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_RoomsCounts_RoomsCountId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "RoomsCountId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyTypeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PropertyStatusId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "GarageCountId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "CityOfPropertyId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BuildingAgeId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BedroomsCountId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "BathroomCountId",
                table: "Properties",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BathroomCounts_BathroomCountId",
                table: "Properties",
                column: "BathroomCountId",
                principalTable: "BathroomCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BedroomsCounts_BedroomsCountId",
                table: "Properties",
                column: "BedroomsCountId",
                principalTable: "BedroomsCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuildingAges_BuildingAgeId",
                table: "Properties",
                column: "BuildingAgeId",
                principalTable: "BuildingAges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_CityOfProperties_CityOfPropertyId",
                table: "Properties",
                column: "CityOfPropertyId",
                principalTable: "CityOfProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_GarageCounts_GarageCountId",
                table: "Properties",
                column: "GarageCountId",
                principalTable: "GarageCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties",
                column: "PropertyStatusId",
                principalTable: "PropertyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

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
                name: "FK_Properties_BathroomCounts_BathroomCountId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BedroomsCounts_BedroomsCountId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_BuildingAges_BuildingAgeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_CityOfProperties_CityOfPropertyId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_GarageCounts_GarageCountId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties");

            migrationBuilder.DropForeignKey(
                name: "FK_Properties_RoomsCounts_RoomsCountId",
                table: "Properties");

            migrationBuilder.AlterColumn<int>(
                name: "RoomsCountId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyTypeId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PropertyStatusId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "GarageCountId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "CityOfPropertyId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BuildingAgeId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BedroomsCountId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "BathroomCountId",
                table: "Properties",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BathroomCounts_BathroomCountId",
                table: "Properties",
                column: "BathroomCountId",
                principalTable: "BathroomCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BedroomsCounts_BedroomsCountId",
                table: "Properties",
                column: "BedroomsCountId",
                principalTable: "BedroomsCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_BuildingAges_BuildingAgeId",
                table: "Properties",
                column: "BuildingAgeId",
                principalTable: "BuildingAges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_CityOfProperties_CityOfPropertyId",
                table: "Properties",
                column: "CityOfPropertyId",
                principalTable: "CityOfProperties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_GarageCounts_GarageCountId",
                table: "Properties",
                column: "GarageCountId",
                principalTable: "GarageCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyStatuses_PropertyStatusId",
                table: "Properties",
                column: "PropertyStatusId",
                principalTable: "PropertyStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_PropertyTypes_PropertyTypeId",
                table: "Properties",
                column: "PropertyTypeId",
                principalTable: "PropertyTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Properties_RoomsCounts_RoomsCountId",
                table: "Properties",
                column: "RoomsCountId",
                principalTable: "RoomsCounts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

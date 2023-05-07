using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WashingCar.Migrations
{
    /// <inheritdoc />
    public partial class ForeignKeysAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "VehicleId",
                table: "VehiclesDetails",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ServicesId",
                table: "Vehicles",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_VehiclesDetails_VehicleId",
                table: "VehiclesDetails",
                column: "VehicleId");

            migrationBuilder.CreateIndex(
                name: "IX_Vehicles_ServicesId",
                table: "Vehicles",
                column: "ServicesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Vehicles_Services_ServicesId",
                table: "Vehicles",
                column: "ServicesId",
                principalTable: "Services",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_VehiclesDetails_Vehicles_VehicleId",
                table: "VehiclesDetails",
                column: "VehicleId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Vehicles_Services_ServicesId",
                table: "Vehicles");

            migrationBuilder.DropForeignKey(
                name: "FK_VehiclesDetails_Vehicles_VehicleId",
                table: "VehiclesDetails");

            migrationBuilder.DropIndex(
                name: "IX_VehiclesDetails_VehicleId",
                table: "VehiclesDetails");

            migrationBuilder.DropIndex(
                name: "IX_Vehicles_ServicesId",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "VehicleId",
                table: "VehiclesDetails");

            migrationBuilder.DropColumn(
                name: "ServicesId",
                table: "Vehicles");
        }
    }
}

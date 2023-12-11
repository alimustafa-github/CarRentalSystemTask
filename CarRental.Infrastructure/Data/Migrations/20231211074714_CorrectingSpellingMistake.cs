using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class CorrectingSpellingMistake : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_LicenseNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LicenseNumber",
                table: "Customers",
                newName: "LicenceNumber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationStartDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationEndDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 194, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LicenceNumber",
                table: "Customers",
                column: "LicenceNumber",
                unique: true,
                filter: "[LicenceNumber] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Customers_LicenceNumber",
                table: "Customers");

            migrationBuilder.RenameColumn(
                name: "LicenceNumber",
                table: "Customers",
                newName: "LicenseNumber");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationStartDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationEndDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(5727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(6288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 194, DateTimeKind.Local).AddTicks(6747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_LicenseNumber",
                table: "Customers",
                column: "LicenseNumber",
                unique: true,
                filter: "[LicenseNumber] IS NOT NULL");
        }
    }
}

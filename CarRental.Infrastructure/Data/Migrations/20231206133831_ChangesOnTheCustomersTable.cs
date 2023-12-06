using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class ChangesOnTheCustomersTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "Customers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationStartDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9105),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationEndDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9812),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(5727),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(6288),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 194, DateTimeKind.Local).AddTicks(6747),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "ApplicationUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EmergencyContactName",
                table: "ApplicationUsers");

            migrationBuilder.DropColumn(
                name: "EmergencyContactNumber",
                table: "ApplicationUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationStartDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(1331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9105));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationEndDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(2033),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 193, DateTimeKind.Local).AddTicks(9812));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(7739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(5727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(8263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 6, 15, 38, 31, 192, DateTimeKind.Local).AddTicks(6288));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(8716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 6, 15, 38, 31, 194, DateTimeKind.Local).AddTicks(6747));

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactName",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmergencyContactNumber",
                table: "Customers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}

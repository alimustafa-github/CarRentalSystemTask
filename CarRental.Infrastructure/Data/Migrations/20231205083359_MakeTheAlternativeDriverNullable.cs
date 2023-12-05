using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class MakeTheAlternativeDriverNullable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Drivers_AlternativeDriverId",
                table: "Drivers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationStartDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(1331),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 19, 43, 43, 665, DateTimeKind.Local).AddTicks(3863));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationEndDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(2033),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 4, 19, 43, 43, 665, DateTimeKind.Local).AddTicks(4515));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(7739),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 19, 43, 43, 664, DateTimeKind.Local).AddTicks(1988));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(8263),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 4, 19, 43, 43, 664, DateTimeKind.Local).AddTicks(2495));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlternativeDriverId",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: true,
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier");

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(8716),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 4, 19, 43, 43, 666, DateTimeKind.Local).AddTicks(306));

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AlternativeDriverId",
                table: "Drivers",
                column: "AlternativeDriverId",
                unique: true,
                filter: "[AlternativeDriverId] IS NOT NULL");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Drivers_AlternativeDriverId",
                table: "Drivers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationStartDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 19, 43, 43, 665, DateTimeKind.Local).AddTicks(3863),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(1331));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ReservationEndDate",
                table: "RentedCars",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 4, 19, 43, 43, 665, DateTimeKind.Local).AddTicks(4515),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(2033));

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 19, 43, 43, 664, DateTimeKind.Local).AddTicks(1988),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(7739));

            migrationBuilder.AlterColumn<DateTime>(
                name: "ContractEndDate",
                table: "Drivers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2024, 6, 4, 19, 43, 43, 664, DateTimeKind.Local).AddTicks(2495),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2024, 6, 5, 10, 33, 59, 501, DateTimeKind.Local).AddTicks(8263));

            migrationBuilder.AlterColumn<Guid>(
                name: "AlternativeDriverId",
                table: "Drivers",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"),
                oldClrType: typeof(Guid),
                oldType: "uniqueidentifier",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "JoinDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2023, 12, 4, 19, 43, 43, 666, DateTimeKind.Local).AddTicks(306),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2023, 12, 5, 10, 33, 59, 503, DateTimeKind.Local).AddTicks(8716));

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_AlternativeDriverId",
                table: "Drivers",
                column: "AlternativeDriverId",
                unique: true);
        }
    }
}

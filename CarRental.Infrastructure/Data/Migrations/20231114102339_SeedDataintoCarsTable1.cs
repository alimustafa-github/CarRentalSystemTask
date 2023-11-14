using CarRental.Core;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataintoCarsTable1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10001, "Sedan", 50.0m, (int)Color.Red, 2.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10002, "SUV", 51.0m, (int)Color.Blue, 2.1m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10003, "Truck", 52.0m, (int)Color.Green, 2.2m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10004, "Convertible", 53.0m, (int)Color.Yellow, 2.3m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10005, "Hatchback", 54.0m, (int)Color.White, 2.4m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10006, "Sedan", 55.0m, (int)Color.Black, 2.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10007, "SUV", 56.0m, (int)Color.Red, 2.6m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10008, "Truck", 57.0m, (int)Color.Blue, 2.7m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10009, "Convertible", 58.0m, (int)Color.Green, 2.8m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10010, "Hatchback", 59.0m, (int)Color.Yellow, 2.9m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10011, "Sedan", 60.0m, (int)Color.White, 3.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10012, "SUV", 61.0m, (int)Color.Black, 3.1m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10013, "Truck", 62.0m, (int)Color.Red, 3.2m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10014, "Convertible", 63.0m, (int)Color.Blue, 3.3m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10015, "Hatchback", 64.0m, (int)Color.Green, 3.4m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10016, "Sedan", 65.0m, (int)Color.Yellow, 3.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10017, "SUV", 66.0m, (int)Color.White, 3.6m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10018, "Truck", 67.0m, (int)Color.Black, 3.7m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10019, "Convertible", 68.0m, (int)Color.Red, 3.8m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 10020, "Hatchback", 69.0m, (int)Color.Blue, 3.9m, false });
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM Cars WHERE SerialNumber LIKE '100%';");
		}
    }
}

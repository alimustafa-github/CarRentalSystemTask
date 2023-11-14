using CarRental.Core;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataintoCarsTable3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50001, "Sedan", 50.0m, (int)Color.Red, 2.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50002, "SUV", 51.0m, (int)Color.Blue, 2.1m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50003, "Hatchback", 52.0m, (int)Color.Black, 2.2m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50004, "Convertible", 55.0m, (int)Color.White, 2.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50005, "Pickup", 60.0m, (int)Color.Green, 3.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50006, "Minivan", 65.0m, (int)Color.Red, 3.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50007, "Coupe", 70.0m, (int)Color.Blue, 4.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50008, "Sedan", 75.0m, (int)Color.Black, 4.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50009, "SUV", 80.0m, (int)Color.White, 5.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50010, "Hatchback", 85.0m, (int)Color.Green, 5.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50011, "Convertible", 90.0m, (int)Color.Red, 6.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50012, "Pickup", 95.0m, (int)Color.Blue, 6.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50013, "Minivan", 100.0m, (int)Color.Black, 7.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50014, "Coupe", 105.0m, (int)Color.White, 7.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50015, "Sedan", 110.0m, (int)Color.Green, 8.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50016, "SUV", 115.0m, (int)Color.Red, 8.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50017, "Hatchback", 120.0m, (int)Color.Blue, 9.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50018, "Convertible", 125.0m, (int)Color.Black, 9.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50019, "Pickup", 130.0m, (int)Color.White, 10.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 50020, "Minivan", 135.0m, (int)Color.Green, 10.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60001, "Sedan", 50.0m, (int)Color.Red, 2.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60002, "SUV", 51.0m, (int)Color.Blue, 2.1m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60003, "Hatchback", 52.0m, (int)Color.Black, 2.2m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60004, "Convertible", 55.0m, (int)Color.White, 2.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60005, "Pickup", 60.0m, (int)Color.Green, 3.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60006, "Minivan", 65.0m, (int)Color.Red, 3.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60007, "Coupe", 70.0m, (int)Color.Blue, 4.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60008, "Sedan", 75.0m, (int)Color.Black, 4.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60009, "SUV", 80.0m, (int)Color.White, 5.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60010, "Hatchback", 85.0m, (int)Color.Green, 5.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60011, "Convertible", 90.0m, (int)Color.Red, 6.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60012, "Pickup", 95.0m, (int)Color.Blue, 6.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60013, "Minivan", 100.0m, (int)Color.Black, 7.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60014, "Coupe", 105.0m, (int)Color.White, 7.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60015, "Sedan", 110.0m, (int)Color.Green, 8.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60016, "SUV", 115.0m, (int)Color.Red, 8.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60017, "Hatchback", 120.0m, (int)Color.Blue, 9.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60018, "Convertible", 125.0m, (int)Color.Black, 9.5m, false });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60019, "Pickup", 130.0m, (int)Color.White, 10.0m, true });

			migrationBuilder.InsertData(
				table: "Cars",
				columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
				values: new object[] { Guid.NewGuid(), 60020, "Minivan", 135.0m, (int)Color.Green, 10.5m, false });
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM Cars WHERE SerialNumber LIKE '500%' OR SerialNumber LIKE '600%';");

		}
	}
}

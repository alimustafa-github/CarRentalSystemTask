using Microsoft.EntityFrameworkCore.Migrations;
using CarRental.Core;
using System;


#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedDataintoCarsTable2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			{
				migrationBuilder.InsertData(
			table: "Cars",
			columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
			values: new object[] { Guid.NewGuid(), 20001, "Sedan", 50.0m, (int)Color.Red, 2.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20002, "SUV", 51.0m, (int)Color.Blue, 2.1m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20003, "Hatchback", 52.0m, (int)Color.Black, 2.2m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20004, "Convertible", 55.0m, (int)Color.White, 2.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20005, "Pickup", 60.0m, (int)Color.Green, 3.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20006, "Minivan", 65.0m, (int)Color.Red, 3.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20007, "Coupe", 70.0m, (int)Color.Blue, 4.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20008, "Sedan", 75.0m, (int)Color.Black, 4.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20009, "SUV", 80.0m, (int)Color.White, 5.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20010, "Hatchback", 85.0m, (int)Color.Green, 5.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20011, "Convertible", 90.0m, (int)Color.Red, 6.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20012, "Pickup", 95.0m, (int)Color.Blue, 6.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20013, "Minivan", 100.0m, (int)Color.Black, 7.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20014, "Coupe", 105.0m, (int)Color.White, 7.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20015, "Sedan", 110.0m, (int)Color.Green, 8.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20016, "SUV", 115.0m, (int)Color.Red, 8.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20017, "Hatchback", 120.0m, (int)Color.Blue, 9.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20018, "Convertible", 125.0m, (int)Color.Black, 9.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20019, "Pickup", 130.0m, (int)Color.White, 10.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 20020, "Minivan", 135.0m, (int)Color.Green, 10.5m, false });


				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30001, "Sedan", 50.0m, (int)Color.Red, 2.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30002, "SUV", 51.0m, (int)Color.Blue, 2.1m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30003, "Hatchback", 52.0m, (int)Color.Black, 2.2m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30004, "Convertible", 55.0m, (int)Color.White, 2.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30005, "Pickup", 60.0m, (int)Color.Green, 3.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30006, "Minivan", 65.0m, (int)Color.Red, 3.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30007, "Coupe", 70.0m, (int)Color.Blue, 4.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30008, "Sedan", 75.0m, (int)Color.Black, 4.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30009, "SUV", 80.0m, (int)Color.White, 5.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30010, "Hatchback", 85.0m, (int)Color.Green, 5.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30011, "Convertible", 90.0m, (int)Color.Red, 6.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30012, "Pickup", 95.0m, (int)Color.Blue, 6.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30013, "Minivan", 100.0m, (int)Color.Black, 7.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30014, "Coupe", 105.0m, (int)Color.White, 7.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30015, "Sedan", 110.0m, (int)Color.Green, 8.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30016, "SUV", 115.0m, (int)Color.Red, 8.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30017, "Hatchback", 120.0m, (int)Color.Blue, 9.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30018, "Convertible", 125.0m, (int)Color.Black, 9.5m, false });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30019, "Pickup", 130.0m, (int)Color.White, 10.0m, true });

				migrationBuilder.InsertData(
					table: "Cars",
					columns: new[] { "Id", "SerialNumber", "Type", "DailyFaire", "Color", "EngineCapacity", "WithDriver" },
					values: new object[] { Guid.NewGuid(), 30020, "Minivan", 135.0m, (int)Color.Green, 10.5m, false });
			}
		
		}

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DELETE FROM Cars WHERE SerialNumber LIKE '200%' OR SerialNumber LIKE '300%';");
		}
    }
}

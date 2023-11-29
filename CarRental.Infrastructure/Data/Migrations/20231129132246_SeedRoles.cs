using CarRental.Core;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CarRental.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.InsertData(
	            table: "ApplicationRoles",
	            columns: new[] { "Id", "Name","NormalizedName", "ConcurrencyStamp" },
	            values: new object[] { Guid.NewGuid().ToString() , AppRoles.Admin.ToString() , AppRoles.Admin.ToString().ToUpper(),Guid.NewGuid().ToString() });
			migrationBuilder.InsertData(
				table: "ApplicationRoles",
				columns: new[] { "Id", "Name", "NormalizedName", "ConcurrencyStamp" },
				values: new object[] { Guid.NewGuid().ToString(), AppRoles.User.ToString(), AppRoles.User.ToString().ToUpper(), Guid.NewGuid().ToString() });
		}

		/// <inheritdoc />
		protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.DeleteData("ApplicationRoles", "Name", AppRoles.Admin.ToString());
			migrationBuilder.DeleteData("ApplicationRoles", "Name", AppRoles.User.ToString());
		}
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL.ClosureTable.Database.Migrations
{
    /// <inheritdoc />
    public partial class InitialOrganizationData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Organizations",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "root" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Organizations",
                keyColumn: "Id",
                keyValue: 1);
        }
    }
}

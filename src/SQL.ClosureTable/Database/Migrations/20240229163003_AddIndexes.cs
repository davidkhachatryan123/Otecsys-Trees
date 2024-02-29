using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SQL.ClosureTable.Database.Migrations
{
    /// <inheritdoc />
    public partial class AddIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_OrganizationClosures_NodeId",
                table: "OrganizationClosures",
                column: "NodeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrganizationClosures_NodeId",
                table: "OrganizationClosures");
        }
    }
}

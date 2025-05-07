using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kollegeni.Migrations
{
    /// <inheritdoc />
    public partial class nyDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "Name" },
                values: new object[] { 2, "Room for playing Pool obviously", "Pool Room" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}

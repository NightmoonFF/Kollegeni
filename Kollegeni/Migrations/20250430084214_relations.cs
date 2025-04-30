using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kollegeni.Migrations
{
    /// <inheritdoc />
    public partial class relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Residencies_ResidencyId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tenants_TenantId",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "ResidencyId",
                table: "Bookings",
                newName: "TenantId1");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_ResidencyId",
                table: "Bookings",
                newName: "IX_Bookings_TenantId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Residencies_TenantId",
                table: "Bookings",
                column: "TenantId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tenants_TenantId1",
                table: "Bookings",
                column: "TenantId1",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Residencies_TenantId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Tenants_TenantId1",
                table: "Bookings");

            migrationBuilder.RenameColumn(
                name: "TenantId1",
                table: "Bookings",
                newName: "ResidencyId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_TenantId1",
                table: "Bookings",
                newName: "IX_Bookings_ResidencyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Residencies_ResidencyId",
                table: "Bookings",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Tenants_TenantId",
                table: "Bookings",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

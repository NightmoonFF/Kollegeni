using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kollegeni.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brugere",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Brugernavn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    KodeOrd = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sprog = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discriminator = table.Column<string>(type: "nvarchar(8)", maxLength: 8, nullable: false),
                    Attribute = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brugere", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Fælleslokaler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fælleslokaler", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Residenser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Størrelse = table.Column<int>(type: "int", nullable: false),
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residenser", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bookinger",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starttidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sluttidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FælleslokaleId = table.Column<int>(type: "int", nullable: false),
                    ResidensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Bookinger", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Bookinger_Fælleslokaler_FælleslokaleId",
                        column: x => x.FælleslokaleId,
                        principalTable: "Fælleslokaler",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Bookinger_Residenser_ResidensId",
                        column: x => x.ResidensId,
                        principalTable: "Residenser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "BrugerResidenser",
                columns: table => new
                {
                    BrugerId = table.Column<int>(type: "int", nullable: false),
                    ResidensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrugerResidenser", x => new { x.BrugerId, x.ResidensId });
                    table.ForeignKey(
                        name: "FK_BrugerResidenser_Brugere_BrugerId",
                        column: x => x.BrugerId,
                        principalTable: "Brugere",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrugerResidenser_Residenser_ResidensId",
                        column: x => x.ResidensId,
                        principalTable: "Residenser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Starttidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sluttidspunkt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ResidensId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Events_Residenser_ResidensId",
                        column: x => x.ResidensId,
                        principalTable: "Residenser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_FælleslokaleId",
                table: "Bookinger",
                column: "FælleslokaleId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_ResidensId",
                table: "Bookinger",
                column: "ResidensId");

            migrationBuilder.CreateIndex(
                name: "IX_BrugerResidenser_ResidensId",
                table: "BrugerResidenser",
                column: "ResidensId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResidensId",
                table: "Events",
                column: "ResidensId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Bookinger");

            migrationBuilder.DropTable(
                name: "BrugerResidenser");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "Fælleslokaler");

            migrationBuilder.DropTable(
                name: "Brugere");

            migrationBuilder.DropTable(
                name: "Residenser");
        }
    }
}

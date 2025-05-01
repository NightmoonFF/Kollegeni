using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Kollegeni.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookinger_Fælleslokaler_FælleslokaleId",
                table: "Bookinger");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookinger_Residenser_ResidensId",
                table: "Bookinger");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Residenser_ResidensId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "BrugerResidenser");

            migrationBuilder.DropTable(
                name: "Fælleslokaler");

            migrationBuilder.DropTable(
                name: "Residenser");

            migrationBuilder.DropIndex(
                name: "IX_Events_ResidensId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookinger",
                table: "Bookinger");

            migrationBuilder.DropIndex(
                name: "IX_Bookinger_ResidensId",
                table: "Bookinger");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Brugere",
                table: "Brugere");

            migrationBuilder.RenameTable(
                name: "Bookinger",
                newName: "Bookings");

            migrationBuilder.RenameTable(
                name: "Brugere",
                newName: "Users");

            migrationBuilder.RenameColumn(
                name: "Starttidspunkt",
                table: "Events",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "Sluttidspunkt",
                table: "Events",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "ResidensId",
                table: "Events",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "Navn",
                table: "Events",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "Beskrivelse",
                table: "Events",
                newName: "Description");

            migrationBuilder.RenameColumn(
                name: "Starttidspunkt",
                table: "Bookings",
                newName: "StartTime");

            migrationBuilder.RenameColumn(
                name: "Sluttidspunkt",
                table: "Bookings",
                newName: "EndTime");

            migrationBuilder.RenameColumn(
                name: "ResidensId",
                table: "Bookings",
                newName: "TenantId");

            migrationBuilder.RenameColumn(
                name: "FælleslokaleId",
                table: "Bookings",
                newName: "RoomId");

            migrationBuilder.RenameIndex(
                name: "IX_Bookinger_FælleslokaleId",
                table: "Bookings",
                newName: "IX_Bookings_RoomId");

            migrationBuilder.RenameColumn(
                name: "Sprog",
                table: "Users",
                newName: "Username");

            migrationBuilder.RenameColumn(
                name: "Mail",
                table: "Users",
                newName: "Password");

            migrationBuilder.RenameColumn(
                name: "KodeOrd",
                table: "Users",
                newName: "Language");

            migrationBuilder.RenameColumn(
                name: "Brugernavn",
                table: "Users",
                newName: "Email");

            migrationBuilder.AddColumn<int>(
                name: "ResidencyId",
                table: "Events",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ResidencyId",
                table: "Bookings",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Residencies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residencies", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserResidencies",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ResidenceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserResidencies", x => new { x.UserId, x.ResidenceId });
                    table.ForeignKey(
                        name: "FK_UserResidencies_Residencies_ResidenceId",
                        column: x => x.ResidenceId,
                        principalTable: "Residencies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserResidencies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResidencyId",
                table: "Events",
                column: "ResidencyId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookings_ResidencyId",
                table: "Bookings",
                column: "ResidencyId");

            migrationBuilder.CreateIndex(
                name: "IX_UserResidencies_ResidenceId",
                table: "UserResidencies",
                column: "ResidenceId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Residencies_ResidencyId",
                table: "Bookings",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Residencies_ResidencyId",
                table: "Events",
                column: "ResidencyId",
                principalTable: "Residencies",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Residencies_ResidencyId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Bookings_Rooms_RoomId",
                table: "Bookings");

            migrationBuilder.DropForeignKey(
                name: "FK_Events_Residencies_ResidencyId",
                table: "Events");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "UserResidencies");

            migrationBuilder.DropTable(
                name: "Residencies");

            migrationBuilder.DropIndex(
                name: "IX_Events_ResidencyId",
                table: "Events");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Bookings",
                table: "Bookings");

            migrationBuilder.DropIndex(
                name: "IX_Bookings_ResidencyId",
                table: "Bookings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResidencyId",
                table: "Events");

            migrationBuilder.DropColumn(
                name: "ResidencyId",
                table: "Bookings");

            migrationBuilder.RenameTable(
                name: "Bookings",
                newName: "Bookinger");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "Brugere");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Events",
                newName: "ResidensId");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Events",
                newName: "Starttidspunkt");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Events",
                newName: "Navn");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Events",
                newName: "Sluttidspunkt");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Events",
                newName: "Beskrivelse");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Bookinger",
                newName: "ResidensId");

            migrationBuilder.RenameColumn(
                name: "StartTime",
                table: "Bookinger",
                newName: "Starttidspunkt");

            migrationBuilder.RenameColumn(
                name: "RoomId",
                table: "Bookinger",
                newName: "FælleslokaleId");

            migrationBuilder.RenameColumn(
                name: "EndTime",
                table: "Bookinger",
                newName: "Sluttidspunkt");

            migrationBuilder.RenameIndex(
                name: "IX_Bookings_RoomId",
                table: "Bookinger",
                newName: "IX_Bookinger_FælleslokaleId");

            migrationBuilder.RenameColumn(
                name: "Username",
                table: "Brugere",
                newName: "Sprog");

            migrationBuilder.RenameColumn(
                name: "Password",
                table: "Brugere",
                newName: "Mail");

            migrationBuilder.RenameColumn(
                name: "Language",
                table: "Brugere",
                newName: "KodeOrd");

            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Brugere",
                newName: "Brugernavn");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Bookinger",
                table: "Bookinger",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Brugere",
                table: "Brugere",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Fælleslokaler",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Beskrivelse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Navn = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    Adresse = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Størrelse = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Residenser", x => x.Id);
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

            migrationBuilder.CreateIndex(
                name: "IX_Events_ResidensId",
                table: "Events",
                column: "ResidensId");

            migrationBuilder.CreateIndex(
                name: "IX_Bookinger_ResidensId",
                table: "Bookinger",
                column: "ResidensId");

            migrationBuilder.CreateIndex(
                name: "IX_BrugerResidenser_ResidensId",
                table: "BrugerResidenser",
                column: "ResidensId");

            migrationBuilder.AddForeignKey(
                name: "FK_Bookinger_Fælleslokaler_FælleslokaleId",
                table: "Bookinger",
                column: "FælleslokaleId",
                principalTable: "Fælleslokaler",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Bookinger_Residenser_ResidensId",
                table: "Bookinger",
                column: "ResidensId",
                principalTable: "Residenser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Events_Residenser_ResidensId",
                table: "Events",
                column: "ResidensId",
                principalTable: "Residenser",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrowLog.Migrations
{
    /// <inheritdoc />
    public partial class AddedActivePlayerList : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "GameId",
                table: "Persons",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GamePerson",
                columns: table => new
                {
                    GamesId = table.Column<int>(type: "INTEGER", nullable: false),
                    PersonId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GamePerson", x => new { x.GamesId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_GamePerson_Games_GamesId",
                        column: x => x.GamesId,
                        principalTable: "Games",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_GamePerson_Persons_PersonId",
                        column: x => x.PersonId,
                        principalTable: "Persons",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Persons_GameId",
                table: "Persons",
                column: "GameId");

            migrationBuilder.CreateIndex(
                name: "IX_GamePerson_PersonId",
                table: "GamePerson",
                column: "PersonId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Persons_Games_GameId",
                table: "Persons",
                column: "GameId",
                principalTable: "Games",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Persons_Games_GameId",
                table: "Persons");

            migrationBuilder.DropTable(
                name: "GamePerson");

            migrationBuilder.DropIndex(
                name: "IX_Persons_GameId",
                table: "Persons");

            migrationBuilder.DropColumn(
                name: "GameId",
                table: "Persons");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}

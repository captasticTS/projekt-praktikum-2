using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrowLog.Migrations
{
    /// <inheritdoc />
    public partial class UpdatedClassesForUsability : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalScore",
                table: "Scores");

            migrationBuilder.AddColumn<int>(
                name: "AuthorId",
                table: "Rulesets",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ShotsAtTargets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AttemptNumber = table.Column<int>(type: "INTEGER", nullable: false),
                    ValueHit = table.Column<int>(type: "INTEGER", nullable: false),
                    ScoreId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShotsAtTargets", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShotsAtTargets_Scores_ScoreId",
                        column: x => x.ScoreId,
                        principalTable: "Scores",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Rulesets_AuthorId",
                table: "Rulesets",
                column: "AuthorId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_OwnerId",
                table: "Games",
                column: "OwnerId");

            migrationBuilder.CreateIndex(
                name: "IX_ShotsAtTargets_ScoreId",
                table: "ShotsAtTargets",
                column: "ScoreId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Rulesets_Persons_AuthorId",
                table: "Rulesets",
                column: "AuthorId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Rulesets_Persons_AuthorId",
                table: "Rulesets");

            migrationBuilder.DropTable(
                name: "ShotsAtTargets");

            migrationBuilder.DropIndex(
                name: "IX_Rulesets_AuthorId",
                table: "Rulesets");

            migrationBuilder.DropIndex(
                name: "IX_Games_OwnerId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "AuthorId",
                table: "Rulesets");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "TotalScore",
                table: "Scores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}

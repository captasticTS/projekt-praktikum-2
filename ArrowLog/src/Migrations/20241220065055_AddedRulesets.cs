using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrowLog.Migrations
{
    /// <inheritdoc />
    public partial class AddedRulesets : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RulesetId",
                table: "Scores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RulesetId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Rulesets",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rulesets", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Scores_RulesetId",
                table: "Scores",
                column: "RulesetId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_RulesetId",
                table: "Games",
                column: "RulesetId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Rulesets_RulesetId",
                table: "Games",
                column: "RulesetId",
                principalTable: "Rulesets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Rulesets_RulesetId",
                table: "Scores",
                column: "RulesetId",
                principalTable: "Rulesets",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Rulesets_RulesetId",
                table: "Games");

            migrationBuilder.DropForeignKey(
                name: "FK_Scores_Rulesets_RulesetId",
                table: "Scores");

            migrationBuilder.DropTable(
                name: "Rulesets");

            migrationBuilder.DropIndex(
                name: "IX_Scores_RulesetId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Games_RulesetId",
                table: "Games");

            migrationBuilder.DropColumn(
                name: "RulesetId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "RulesetId",
                table: "Games");
        }
    }
}

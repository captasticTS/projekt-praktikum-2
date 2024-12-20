using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrowLog.Migrations
{
    /// <inheritdoc />
    public partial class FixedRuleset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "HitType",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Title = table.Column<string>(type: "TEXT", nullable: false),
                    Values = table.Column<string>(type: "TEXT", nullable: false),
                    RulesetId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HitType", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HitType_Rulesets_RulesetId",
                        column: x => x.RulesetId,
                        principalTable: "Rulesets",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_HitType_RulesetId",
                table: "HitType",
                column: "RulesetId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "HitType");
        }
    }
}

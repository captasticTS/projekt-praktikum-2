using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrowLog.Migrations
{
    /// <inheritdoc />
    public partial class Update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games");

            migrationBuilder.AddColumn<int>(
                name: "OwnerId",
                table: "Scores",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Scores_OwnerId",
                table: "Scores",
                column: "OwnerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Scores_Persons_OwnerId",
                table: "Scores",
                column: "OwnerId",
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
                name: "FK_Scores_Persons_OwnerId",
                table: "Scores");

            migrationBuilder.DropIndex(
                name: "IX_Scores_OwnerId",
                table: "Scores");

            migrationBuilder.DropColumn(
                name: "OwnerId",
                table: "Scores");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Persons_OwnerId",
                table: "Games",
                column: "OwnerId",
                principalTable: "Persons",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ArrowLog.Migrations
{
    /// <inheritdoc />
    public partial class AddedParcoursToGame : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Parcours_ParcoursId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "ParcoursId",
                table: "Games",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "INTEGER",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Parcours_ParcoursId",
                table: "Games",
                column: "ParcoursId",
                principalTable: "Parcours",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Games_Parcours_ParcoursId",
                table: "Games");

            migrationBuilder.AlterColumn<int>(
                name: "ParcoursId",
                table: "Games",
                type: "INTEGER",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "INTEGER");

            migrationBuilder.AddForeignKey(
                name: "FK_Games_Parcours_ParcoursId",
                table: "Games",
                column: "ParcoursId",
                principalTable: "Parcours",
                principalColumn: "Id");
        }
    }
}

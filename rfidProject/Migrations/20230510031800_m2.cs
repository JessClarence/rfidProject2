using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rfidProject.Migrations
{
    /// <inheritdoc />
    public partial class m2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CattleRegId",
                table: "SlaughterCattles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SlaughterCattles_CattleRegId",
                table: "SlaughterCattles",
                column: "CattleRegId");

            migrationBuilder.AddForeignKey(
                name: "FK_SlaughterCattles_CattleRegs_CattleRegId",
                table: "SlaughterCattles",
                column: "CattleRegId",
                principalTable: "CattleRegs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SlaughterCattles_CattleRegs_CattleRegId",
                table: "SlaughterCattles");

            migrationBuilder.DropIndex(
                name: "IX_SlaughterCattles_CattleRegId",
                table: "SlaughterCattles");

            migrationBuilder.DropColumn(
                name: "CattleRegId",
                table: "SlaughterCattles");
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rfidProject.Migrations
{
    /// <inheritdoc />
    public partial class m1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CattleRegs_Rfids_RfidId",
                table: "CattleRegs");

            migrationBuilder.DropForeignKey(
                name: "FK_CattleRegs_SlaughterCattles_SlaughterCattleId",
                table: "CattleRegs");

            migrationBuilder.DropIndex(
                name: "IX_CattleRegs_RfidId",
                table: "CattleRegs");

            migrationBuilder.DropIndex(
                name: "IX_CattleRegs_SlaughterCattleId",
                table: "CattleRegs");

            migrationBuilder.DropColumn(
                name: "RfidId",
                table: "CattleRegs");

            migrationBuilder.DropColumn(
                name: "SlaughterCattleId",
                table: "CattleRegs");

            migrationBuilder.AddColumn<string>(
                name: "Rfid",
                table: "CattleRegs",
                type: "longtext",
                nullable: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rfid",
                table: "CattleRegs");

            migrationBuilder.AddColumn<int>(
                name: "RfidId",
                table: "CattleRegs",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SlaughterCattleId",
                table: "CattleRegs",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_CattleRegs_RfidId",
                table: "CattleRegs",
                column: "RfidId");

            migrationBuilder.CreateIndex(
                name: "IX_CattleRegs_SlaughterCattleId",
                table: "CattleRegs",
                column: "SlaughterCattleId");

            migrationBuilder.AddForeignKey(
                name: "FK_CattleRegs_Rfids_RfidId",
                table: "CattleRegs",
                column: "RfidId",
                principalTable: "Rfids",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CattleRegs_SlaughterCattles_SlaughterCattleId",
                table: "CattleRegs",
                column: "SlaughterCattleId",
                principalTable: "SlaughterCattles",
                principalColumn: "Id");
        }
    }
}

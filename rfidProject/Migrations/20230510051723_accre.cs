using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rfidProject.Migrations
{
    /// <inheritdoc />
    public partial class accre : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "AccreditationRate",
                table: "SlaughterHouses",
                type: "int",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "longtext",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "AccreditationRate",
                table: "SlaughterHouses",
                type: "longtext",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);
        }
    }
}

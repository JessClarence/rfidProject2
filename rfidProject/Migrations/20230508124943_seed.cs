using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace rfidProject.Migrations
{
    /// <inheritdoc />
    public partial class seed : Migration
    {
        private string ProducerRoleId = Guid.NewGuid().ToString();
        private string SlaughterHouseRoleId = Guid.NewGuid().ToString();
        private string UserRoleId = Guid.NewGuid().ToString();
        private string AdminRoleId = Guid.NewGuid().ToString();

        private string User1Id = "0f57d976-5a4b-4ffc-9d6d-ffb506ce0b5d"; //adrianne
        private string User2Id = "4a69c1df-2429-4a2c-ad68-f46c24e86a48"; // gerico
        private string User3Id = "84cdfd8d-f15b-4b44-81ba-5aa14b936ce9"; // admin
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            SeedRolesSQL(migrationBuilder);

            SeedUserRoles(migrationBuilder);
        }

        private void SeedRolesSQL(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles (Id,Name,NormalizedName,ConcurrencyStamp)
            VALUES ('{AdminRoleId}', 'Administrator', 'ADMINISTRATOR', null);");
            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles (Id,Name,NormalizedName,ConcurrencyStamp)
            VALUES ('{ProducerRoleId}', 'Producer', 'PRODUCER', null);");
            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles (Id,Name,NormalizedName,ConcurrencyStamp)
            VALUES ('{SlaughterHouseRoleId}', 'SlaughterHouse', 'SLAUGHTERHOUSE', null);");
            migrationBuilder.Sql(@$"INSERT INTO AspNetRoles (Id,Name,NormalizedName,ConcurrencyStamp)
            VALUES ('{UserRoleId}', 'User', 'USER', null);");
        }

        private void SeedUserRoles(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@$"
        INSERT INTO AspNetUserRoles
           (UserId
           ,RoleId)
        VALUES
           ('{User1Id}', '{ProducerRoleId}');
        INSERT INTO AspNetUserRoles
           (UserId
           ,RoleId)
        VALUES
           ('{User1Id}', '{AdminRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO AspNetUserRoles
           (UserId
           ,RoleId)
        VALUES
           ('{User3Id}', '{UserRoleId}');
        INSERT INTO AspNetUserRoles
           (UserId
           ,RoleId)
        VALUES
           ('{User3Id}', '{AdminRoleId}');");

            migrationBuilder.Sql(@$"
        INSERT INTO AspNetUserRoles
           (UserId
           ,RoleId)
        VALUES
           ('{User2Id}', '{AdminRoleId}');
        INSERT INTO AspNetUserRoles
           (UserId
           ,RoleId)
        VALUES
           ('{User2Id}', '{SlaughterHouseRoleId}');");

        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}

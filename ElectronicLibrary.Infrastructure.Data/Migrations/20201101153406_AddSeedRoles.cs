using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class AddSeedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e30d56b0-865e-424d-ae77-5a04efa8d370", "3ca77900-a4ba-4ecd-8277-862207685f4e", "User", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37d9d75f-d072-4d58-981e-d720f07eecec", "02141aa5-91e0-4565-b05e-024b73b5ea0c", "Moderator", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "37d9d75f-d072-4d58-981e-d720f07eecec");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e30d56b0-865e-424d-ae77-5a04efa8d370");
        }
    }
}

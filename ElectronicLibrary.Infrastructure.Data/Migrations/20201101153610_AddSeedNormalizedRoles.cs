using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class AddSeedNormalizedRoles : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "37d9d75f-d072-4d58-981e-d720f07eecec");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "e30d56b0-865e-424d-ae77-5a04efa8d370");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd8bf2bf-a7c3-406b-93c4-2886987f7486", "3b403567-ba72-4b6a-a471-37e6d9f6bc41", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "874a6f6d-8932-4727-ace9-d48a3360f441", "39c1e1a6-1118-4934-9115-006a7826fb3b", "Moderator", "MODERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "874a6f6d-8932-4727-ace9-d48a3360f441");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dd8bf2bf-a7c3-406b-93c4-2886987f7486");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "e30d56b0-865e-424d-ae77-5a04efa8d370", "3ca77900-a4ba-4ecd-8277-862207685f4e", "User", null });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "37d9d75f-d072-4d58-981e-d720f07eecec", "02141aa5-91e0-4565-b05e-024b73b5ea0c", "Moderator", null });
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class ChangeGenreType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "874a6f6d-8932-4727-ace9-d48a3360f441");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "dd8bf2bf-a7c3-406b-93c4-2886987f7486");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Genres",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c57b022e-a4ea-4d14-8de0-81c35a30f9c0", "edd938bf-154c-41cd-ab3d-f1175e708719", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f32c246-559c-49a5-80d0-0177dd0e4289", "ac404346-065e-4c64-bc87-271ab0c8a96c", "Moderator", "MODERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3f32c246-559c-49a5-80d0-0177dd0e4289");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c57b022e-a4ea-4d14-8de0-81c35a30f9c0");

            migrationBuilder.AlterColumn<int>(
                name: "Name",
                table: "Genres",
                type: "int",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "dd8bf2bf-a7c3-406b-93c4-2886987f7486", "3b403567-ba72-4b6a-a471-37e6d9f6bc41", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "874a6f6d-8932-4727-ace9-d48a3360f441", "39c1e1a6-1118-4934-9115-006a7826fb3b", "Moderator", "MODERATOR" });
        }
    }
}

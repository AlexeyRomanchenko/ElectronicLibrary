using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class UpdateSeedBooksData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "57248d3b-94a6-4dee-9fbd-d87b6a5578a2");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "fb005787-d24e-4e0c-9b92-4ed7dee7fdba");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/fairytale-old-vintage-book-cover-template-design-5ff0b48b07be66f694dcd67101cefa12_screen.jpg?ts=1566579743");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/fairytale-old-vintage-book-cover-template-design-5ff0b48b07be66f694dcd67101cefa12_screen.jpg?ts=1566579743");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: "https://d1csarkz8obe9u.cloudfront.net/posterpreviews/fairytale-old-vintage-book-cover-template-design-5ff0b48b07be66f694dcd67101cefa12_screen.jpg?ts=1566579743");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "7d2686ff-93df-4c2d-b271-e6bb436957e5", "c4387e58-2e87-4f9d-846c-23e6f920a5d1", "User", "USER" },
                    { "37378793-847b-46ba-8c13-80aa5d03f91e", "d253c8b4-73f9-4229-ad54-17dc9f880f52", "Moderator", "MODERATOR" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "37378793-847b-46ba-8c13-80aa5d03f91e");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "7d2686ff-93df-4c2d-b271-e6bb436957e5");

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2,
                column: "ImagePath",
                value: null);

            migrationBuilder.UpdateData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3,
                column: "ImagePath",
                value: null);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "57248d3b-94a6-4dee-9fbd-d87b6a5578a2", "66f119fe-1b0c-4eda-9b07-8aacfea06b79", "User", "USER" },
                    { "fb005787-d24e-4e0c-9b92-4ed7dee7fdba", "37b20ca5-054c-496f-8ed2-ef13703ebbe0", "Moderator", "MODERATOR" }
                });
        }
    }
}

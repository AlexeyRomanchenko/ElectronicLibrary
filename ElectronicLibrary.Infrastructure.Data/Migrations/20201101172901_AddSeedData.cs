using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class AddSeedData : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "3f32c246-559c-49a5-80d0-0177dd0e4289");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c57b022e-a4ea-4d14-8de0-81c35a30f9c0");

            migrationBuilder.InsertData(
                table: "Authors",
                columns: new[] { "Id", "Firstname", "Lastname" },
                values: new object[,]
                {
                    { 1, "Jeffrey", "Richter" },
                    { 2, "Vicktor Marie", "Hugo" },
                    { 3, "Artur Konan", "Doyle" }
                });

            migrationBuilder.InsertData(
                table: "Genres",
                columns: new[] { "GenreId", "Name" },
                values: new object[,]
                {
                    { 1, "Programming" },
                    { 2, "Sci-fi" },
                    { 3, "Detective" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "ffcefeea-679c-4b1d-9965-1661cb6cc453", "8364ea85-edaf-4f3d-9d6a-54e2e421e235", "User", "USER" },
                    { "a35d8674-8d6b-4c5f-9ceb-0735d0d27292", "5b68ada4-1737-4201-b122-f66fb0143658", "Moderator", "MODERATOR" }
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "GenreId", "ImagePath", "Name", "PublishYear", "TotalAmount" },
                values: new object[] { 1, 1, 1, null, ".NET via CLR", new DateTime(2016, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 3 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "GenreId", "ImagePath", "Name", "PublishYear", "TotalAmount" },
                values: new object[] { 2, 3, 3, null, "Sherlock Holms", new DateTime(1860, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 2 });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "AuthorId", "GenreId", "ImagePath", "Name", "PublishYear", "TotalAmount" },
                values: new object[] { 3, 2, 3, null, "Outcasts", new DateTime(1860, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "a35d8674-8d6b-4c5f-9ceb-0735d0d27292");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "ffcefeea-679c-4b1d-9965-1661cb6cc453");

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Authors",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Genres",
                keyColumn: "GenreId",
                keyValue: 3);

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c57b022e-a4ea-4d14-8de0-81c35a30f9c0", "edd938bf-154c-41cd-ab3d-f1175e708719", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "3f32c246-559c-49a5-80d0-0177dd0e4289", "ac404346-065e-4c64-bc87-271ab0c8a96c", "Moderator", "MODERATOR" });
        }
    }
}

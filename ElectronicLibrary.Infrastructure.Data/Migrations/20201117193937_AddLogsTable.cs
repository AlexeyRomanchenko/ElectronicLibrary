using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class AddLogsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "367f553d-58d3-450e-8048-527f1489fb81");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "c9c6ae40-6480-404e-ba62-6c59fe99b92d");

            migrationBuilder.CreateTable(
                name: "Logs",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(nullable: true),
                    BookId = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Logs", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Logs_Books_BookId",
                        column: x => x.BookId,
                        principalTable: "Books",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Logs_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d1f0a1c-aa0c-48e0-a25d-7cb6c47d8104", "e75c7a5e-6462-4205-b096-5ac62de22109", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "543507fa-10be-45f2-bb4f-5035305719ca", "939165fc-47b2-4fcd-93bd-498f0669db27", "Moderator", "MODERATOR" });

            migrationBuilder.CreateIndex(
                name: "IX_Logs_BookId",
                table: "Logs",
                column: "BookId");

            migrationBuilder.CreateIndex(
                name: "IX_Logs_UserId",
                table: "Logs",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Logs");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "543507fa-10be-45f2-bb4f-5035305719ca");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9d1f0a1c-aa0c-48e0-a25d-7cb6c47d8104");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "367f553d-58d3-450e-8048-527f1489fb81", "bb7661e9-9194-43b2-86da-f4ea701084d9", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "c9c6ae40-6480-404e-ba62-6c59fe99b92d", "f8f15930-3b10-4040-8d58-de7934f6bf95", "Moderator", "MODERATOR" });
        }
    }
}

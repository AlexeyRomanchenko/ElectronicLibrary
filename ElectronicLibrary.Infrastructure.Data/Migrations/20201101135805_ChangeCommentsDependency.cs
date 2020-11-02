using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class ChangeCommentsDependency : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Bookings_BookingId",
                table: "Comments");

            migrationBuilder.DropIndex(
                name: "IX_Comments_BookingId",
                table: "Comments");

            migrationBuilder.DropColumn(
                name: "BookingId",
                table: "Comments");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookingId",
                table: "Comments",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Comments_BookingId",
                table: "Comments",
                column: "BookingId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Bookings_BookingId",
                table: "Comments",
                column: "BookingId",
                principalTable: "Bookings",
                principalColumn: "BookingId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}

using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class MakeGuidsForRolesStoredProcedure : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"USE [ElectricLibrary]
GO
/****** Object:  StoredProcedure [dbo].[RemoveIssuedBookings]    Script Date: 11/19/2020 9:38:19 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexey Romanchenko
-- Create date: 2020-11-06
-- Description:	Procedure scans bookings and
-- remove issued bookings
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[RemoveIssuedBookings]
AS
BEGIN

	BEGIN TRY
	BEGIN TRANSACTION
	PRINT 'STARTED';
	SET NOCOUNT ON;
	Update Bookings SET Status = 'Cancelled'
	OUTPUT deleted.*
	WHERE IssueDate < GETDATE() AND Status = 'Booking';
	SET NOCOUNT OFF;
	PRINT 'FINISHED';
	COMMIT TRANSACTION
	END TRY
	

	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION;
		RETURN -1;
	END CATCH
END
");
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
                values: new object[] { "9698a61d-ac44-41f7-baea-282a6a706fd3", "d72a4008-ac11-485b-bbb0-f261592a20ed", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "2d29ad54-7b0f-436b-a49c-f45be0c7d7ee", "a710351c-e035-46c5-8fe3-60e40121a460", "Moderator", "MODERATOR" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.RemoveIssuedBookings");
            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "2d29ad54-7b0f-436b-a49c-f45be0c7d7ee");

            migrationBuilder.DeleteData(
                table: "Roles",
                keyColumn: "Id",
                keyValue: "9698a61d-ac44-41f7-baea-282a6a706fd3");

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "9d1f0a1c-aa0c-48e0-a25d-7cb6c47d8104", "e75c7a5e-6462-4205-b096-5ac62de22109", "User", "USER" });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "543507fa-10be-45f2-bb4f-5035305719ca", "939165fc-47b2-4fcd-93bd-498f0669db27", "Moderator", "MODERATOR" });
        }
    }
}

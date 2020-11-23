using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class CreateFunctionEmailBookingIssued : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		Alexey Romanchenko
-- Create date: 20.11.2020
-- Description:	Function returns emails with expired status
-- =============================================
CREATE OR ALTER FUNCTION [dbo].[GetUsersWithExpiredBusyStatus]
()
RETURNS 
@emails TABLE 
(
email NVARCHAR(256),
bookingId INT,
book NVARCHAR(256),
bookingDate DATETIME2
) AS
BEGIN
	DECLARE @user_ids CURSOR;
	DECLARE @Id NVARCHAR(36);
    DECLARE @BookingDate DATETIME2;
    DECLARE @BookingId INT;
    DECLARE @BookName NVARCHAR(256);
	SET @user_ids = CURSOR FOR (
		SELECT Bookings.UserId, Bookings.BookingDate,Bookings.BookingId, Books.Name 
		FROM Bookings 
		JOIN Books ON Bookings.BookId = Books.Id  
		WHERE Bookings.Status = 'Busy' 
		AND Bookings.IssueDate < GETDATE())
	OPEN @user_ids
	FETCH NEXT FROM @user_ids INTO @Id, @BookingDate,@BookingId, @BookName
	WHILE @@FETCH_STATUS = 0
		BEGIN
			INSERT INTO @emails (email, bookingDate, bookingId, book) 
			SELECT UserName as email, @BookingDate,@BookingId, @BookName FROM Users WHERE Id = @Id;
			FETCH NEXT FROM @user_ids INTO @Id, @BookingDate,@BookingId, @BookName
		END
		CLOSE @user_ids
	RETURN;
END
GO

");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
			migrationBuilder.Sql("DROP FUNCTION IF EXISTS dbo.GetUsersWithExpiredBusyStatus");
        }
    }
}

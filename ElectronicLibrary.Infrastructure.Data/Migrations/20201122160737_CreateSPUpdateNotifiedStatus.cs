using Microsoft.EntityFrameworkCore.Migrations;

namespace ElectronicLibrary.Infrastructure.Data.Migrations
{
    public partial class CreateSPUpdateNotifiedStatus : Migration
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
-- Create date: 2020-11-22
-- Description:	Procedure sets bookings as notified with email letter
-- =============================================
CREATE OR ALTER PROCEDURE [dbo].[SetBookingAsNotified]
(
    @BookingId INT
)
AS
BEGIN

	BEGIN TRY
	BEGIN TRANSACTION
    UPDATE Bookings SET Status = 'Notified' WHERE BookingId = @BookingId;
	COMMIT TRANSACTION
	END TRY
	
	BEGIN CATCH
		PRINT ERROR_MESSAGE()
		ROLLBACK TRANSACTION;
		RETURN -1;
	END CATCH
END

GO
");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP PROCEDURE IF EXISTS dbo.SetBookingAsNotified");
        }
    }
}

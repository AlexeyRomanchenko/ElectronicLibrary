using ElectronicLibrary.Domain.Core.Identity;
using System;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicLibrary.Domain.Core.Library
{
    public class Booking
    {
        [Column("BookingId")]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

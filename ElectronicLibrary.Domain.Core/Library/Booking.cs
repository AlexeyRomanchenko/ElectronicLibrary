using ElectronicLibrary.Domain.Core.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicLibrary.Domain.Core.Library
{
    public class Booking
    {
        [Column("BookingId")]
        public int Id { get; set; }
        public DateTime BookingDate { get; set; }
        public DateTime IssueDate { get; set; }
        public int BookId { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public Book Book { get; set; }
        public Status Status { get; set; }
    }
}

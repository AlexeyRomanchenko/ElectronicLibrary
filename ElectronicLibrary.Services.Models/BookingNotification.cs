using System;
using System.Collections.Generic;
using System.Text;

namespace ElectronicLibrary.Services.Models
{
    public class BookingNotification
    {
        public string Email { get; set; }
        public string Book { get; set; }
        public int BookingId { get; set; }
        public DateTime BookingDate { get; set; }
    }
}

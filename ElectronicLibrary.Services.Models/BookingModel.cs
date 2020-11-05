using System;

namespace ElectronicLibrary.Services.Models
{
    public class BookingModel
    {
        public readonly int _bookId;
        public readonly string _userId;
        public BookingModel(int bookId, string userId)
        {
            this._bookId = bookId;
            this._userId = userId;
        }
    }
}

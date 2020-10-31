using System;

namespace ElectronicLibrary.Domain.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime ReleaseYear { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string ImagePath { get; set; }
        public int TotalAmount { get; set; }
    }
}

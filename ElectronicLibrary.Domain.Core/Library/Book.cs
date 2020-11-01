using ElectronicLibrary.Domain.Core.Library;
using System;
using System.Collections.Generic;

namespace ElectronicLibrary.Domain.Core
{
    public class Book
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime PublishYear { get; set; }
        public int AuthorId { get; set; }
        public Author Author { get; set; }
        public int GenreId { get; set; }
        public Genre Genre { get; set; }
        public string ImagePath { get; set; }
        public int TotalAmount { get; set; }
        public List<Comment> Comments { get; set; }
    }
}

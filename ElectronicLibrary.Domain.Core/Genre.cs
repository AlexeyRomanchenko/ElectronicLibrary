using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicLibrary.Domain.Core
{
    public class Genre
    {
        [Column("GenreId")]
        public int Id { get; set; }
        public int Name { get; set; }
        public List<Book> Books { get; set; }
    }
}

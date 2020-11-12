using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ElectronicLibraryWebApp.ViewModels
{
    public class BookViewModel
    {
        [Required(ErrorMessage ="You can not create a book without a name")]
        public string Name { get; set; }
        [Required(ErrorMessage ="Total amount of books is required")]
        public int TotalAmount { get; set; }
        [Required(ErrorMessage = "Please, enter book's publish year")]
        public DateTime PublishYear { get; set; }
        [Required(ErrorMessage = "Please, select image for the book")]
        public string ImagePath { get; set; }
        [Required(ErrorMessage = "Please , select a genre for this book")]
        public int GenreId { get; set; }
        [Required(ErrorMessage = "Please , select an author for this book")]
        public int AuthorId { get; set; }
    }
}

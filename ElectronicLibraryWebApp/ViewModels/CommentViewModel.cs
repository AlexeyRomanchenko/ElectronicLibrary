using System.ComponentModel.DataAnnotations;

namespace ElectronicLibraryWebApp.ViewModels
{
    public class CommentViewModel
    {
        [Required(ErrorMessage ="Book is not defined")]
        public int BookId { get; set; }
        [Required(ErrorMessage ="Text cannot be empty")]
        public string Text { get; set; }
    }
}

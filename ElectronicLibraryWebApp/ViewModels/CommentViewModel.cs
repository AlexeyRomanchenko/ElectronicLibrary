using System.ComponentModel.DataAnnotations;

namespace ElectronicLibraryWebApp.ViewModels
{
    public class CommentViewModel
    {
        [Required(ErrorMessage ="Book is not defined")]
        public int BookId { get; set; }
        [MaxLength(3000)]
        [Required(ErrorMessage ="Text cannot be empty")]
        public string Text { get; set; }
        [MaxLength(200)]
        [Required(ErrorMessage = "Theme cannot be empty")]
        public string Theme { get; set; }
    }
}

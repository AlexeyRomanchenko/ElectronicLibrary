using System.ComponentModel.DataAnnotations;

namespace ElectronicLibraryWebApp.ViewModels
{
    public class AuthorViewModel
    {
        [Required(ErrorMessage ="Author has to have a firstname")]
        public string Firstname { get; set; }
        [Required(ErrorMessage = "Author has to have a lastname")]
        public string Lastname { get; set; }
    }
}

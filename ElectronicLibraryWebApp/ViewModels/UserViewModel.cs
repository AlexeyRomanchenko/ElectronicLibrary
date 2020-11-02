using System.ComponentModel.DataAnnotations;
namespace ElectronicLibraryWebApp.ViewModels
{
    public class UserViewModel
    {
        [Required(ErrorMessage ="Sorry, but field Username is necessary")]
        public string Username { get; set; }
        [Required(ErrorMessage ="Sorry, but field Password is necessary")]
        public string Password { get; set; }
    }
}

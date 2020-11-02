using System.ComponentModel.DataAnnotations;
namespace ElectronicLibraryWebApp.ViewModels
{
    public class RegisterViewModel : UserViewModel
    {
        [Required]
        [Compare("Password", ErrorMessage ="Passwords are different")]
        public string ConfirmPassword{get;set;}
    }
}

using System.ComponentModel.DataAnnotations;

namespace ElectronicLibraryWebApp.ViewModels
{
    public class GenreViewModel
    {
        [Required(ErrorMessage ="Genre must have a name")]
        public string Name{get;set;}
    }
}

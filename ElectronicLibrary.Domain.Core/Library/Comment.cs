using ElectronicLibrary.Domain.Core.Identity;
using System.ComponentModel.DataAnnotations;

namespace ElectronicLibrary.Domain.Core.Library
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        [MaxLength(200)]
        public string Theme { get; set; }
        [Required]
        [MaxLength(3000)]
        public string Text { get; set; }
        [Required]
        public int BookId { get; set; }
        [Required]
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsBlocked { get; set; }

    }
}
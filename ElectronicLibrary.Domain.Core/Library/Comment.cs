using ElectronicLibrary.Domain.Core.Identity;

namespace ElectronicLibrary.Domain.Core.Library
{
    public class Comment
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public int BookId { get; set; }
        public Book Book { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        public bool IsBlocked { get; set; }

    }
}
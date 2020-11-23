using ElectronicLibrary.Domain.Core.Identity;

namespace ElectronicLibrary.Domain.Core.Library
{
    public class Log
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int BookId { get; set; }
        public Book Book{ get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

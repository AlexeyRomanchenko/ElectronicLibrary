namespace ElectronicLibrary.Domain.Core.Library
{
    public class Warehouse
    {
        public int BookId { get; set; } 
        public Book Book{ get; set; }
        public int Amount { get; set; }

    }
}

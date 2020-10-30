using System.ComponentModel.DataAnnotations.Schema;
namespace ElectronicLibrary.Domain.Core.Identity
{
    public class User
    {
        [Column("UserId")]
        public int Id { get; set; }
        public string Username { get; set; }

    }
}

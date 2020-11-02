using System.Threading.Tasks;

namespace EletronicLibrary.Services.Interfaces
{
    public interface IAuth
    {
        Task<string> GenerateJWT();
    }
}

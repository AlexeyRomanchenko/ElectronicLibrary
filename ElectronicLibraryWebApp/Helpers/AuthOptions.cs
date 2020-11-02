using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace ElectronicLibraryWebApp.Helpers
{
    public class AuthOptions
    {
        public const string ISSUER = "EBookShopServer";
        public const string AUDIENCE = "Client";
        const string KEY = "mysupersecret_secretkey!123";  
        public const int LIFETIME = 60;
        public static SymmetricSecurityKey GetSymmetricSecurityKey()
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(KEY));
        }
    }
}

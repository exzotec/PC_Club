using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PC_Club
{
    public class AuthOption
    {
        public const string ISSUER = "Exzotec"; // издатель токена
        public const string AUDIENCE = "User"; // потребитель токена
        public const double LIFETIME = 20; // время жизни токена
        const string KEY = "PC_Club_secretKey_exzotec";   // ключ для шифрации
        public static SymmetricSecurityKey GetSymmetricSecurityKey() =>
            new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}

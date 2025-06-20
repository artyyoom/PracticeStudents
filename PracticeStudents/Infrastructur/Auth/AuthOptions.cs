using Microsoft.IdentityModel.Tokens;
using System.Text;

public static class AuthOptions
{
    public const string ISSUER = "YourIssuer";
    public const string AUDIENCE = "YourAudience";
    private const string KEY = "mysupersecretkey_must_be_32_bytes!";

    public static SymmetricSecurityKey GetSymmetricSecurityKey()
    {
        return new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY));
    }
}

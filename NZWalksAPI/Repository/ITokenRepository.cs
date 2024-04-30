using Microsoft.AspNetCore.Identity;

namespace NZWalksAPI.Repository
{
    public interface ITokenRepository
    {
        string CreateJWToken(IdentityUser user, List<string> roles);

    }
}

using NATA.Entities;

namespace NATA.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);
    }
}
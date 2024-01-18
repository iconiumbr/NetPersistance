using FiapStore.Entity;

namespace FiapStore.Services
{
    public interface ITokenService
    {
        string GetToken(User user);
    }
}

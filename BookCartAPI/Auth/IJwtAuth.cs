using System.Threading.Tasks;

namespace BookCartAPI.Auth
{
    public interface IJwtAuth
    {
        Task<TokenResponse> Authentication(string username, string password);
    }
}

using N_Health_API.Models;
using N_Health_API.Models.Shared;

namespace N_Health_API.ServicesInterfece.Shared
{
    public interface IAccessTokenService
    {       
        Task<MessageResponseModel> CheckAuthService(string? token, string? userCode);
        Task<MessageResponseModel> CheckerLoginService(LoginRequest user);
    }
}

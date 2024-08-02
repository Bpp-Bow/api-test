using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;

namespace N_Health_API.ServicesInterfece.Master
{
    public interface IUserinfoService
    {
        Task<MessageResponseModel> SearchService(SearchPermissionModel data);
        Task<MessageResponseModel> GetByIdService(int id);
        Task<MessageResponseModel> AddService(UserinfoModel data, string? userName);
        Task<MessageResponseModel> EditService(UserinfoModel data, string? userName);
        Task<MessageResponseModel> ChangeActiveService(int id, bool isActive, string? userName);
        Task<MessageResponseModel> CheckUserByUserNameService(string? userName);
    }
}

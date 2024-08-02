using N_Health_API.Models.Master;

namespace N_Health_API.RepositoriesInterface.Master
{
    public interface IUserinfoData
    {
        Task<bool> Add(UserinfoModel data, string? userName);
        Task<bool> Edit(UserinfoModel? data, string? userName);
        Task<bool> ChangeActive(int id, bool isActive, string? userName);
        Task<UserinfoModel> CheckUserByUserName(string user);
    }
}

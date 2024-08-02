using N_Health_API.Models;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;

namespace N_Health_API.RepositoriesInterface.Shared
{
    public interface IAuthenRepository
    {       
        Task<MessageResponseModel> CheckerLogin(string user);
    }
}

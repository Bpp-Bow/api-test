using N_Health_API.Core;
using N_Health_API.Helper;
using N_Health_API.Models;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;
using N_Health_API.RepositoriesInterface;
using N_Health_API.RepositoriesInterface.Master;
using N_Health_API.RepositoriesInterface.Shared;
using System.Data;
using System.IdentityModel.Tokens.Jwt;

namespace N_Health_API.Repositories.Shared
{
    public class AuthenRepository : IAuthenRepository
    {
        private IConfiguration _config;
        private IUserinfoData _sUserInfo;

        public AuthenRepository(IConfiguration config, IUserinfoData sUserInfo)
        {
            //_db = db;
            _config = config;
            _sUserInfo = sUserInfo;

        }
        public async Task<MessageResponseModel> CheckerLogin(string user)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;
            try
            {
                UserinfoModel result = await _sUserInfo.CheckUserByUserName(user);
                if (result != null) 
                {
                    meg_res.Message = ReturnMessage.SUCCESS;
                    meg_res.Code = ReturnCode.SUCCESS;
                    meg_res.Success = true;
                    meg_res.Data = result;
                }
                
                return meg_res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        
    }
}

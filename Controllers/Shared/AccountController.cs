using Microsoft.AspNetCore.Mvc;
using N_Health_API.Services;
using N_Health_API.Models;
using Swashbuckle.AspNetCore.Annotations;
using N_Health_API.Models.Shared;
using System.Security;
using N_Health_API.ServicesInterfece.Master;
using N_Health_API.ServicesInterfece.Shared;

namespace N_Health_API.Controllers
{
    [Route("Account")]
    public class AccountController : Controller
    {
        //private readonly AccessTokenService _accessTokenService;
        private readonly IConfiguration _configuration;
        private readonly IAccessTokenService _iAccessToken;
        public AccountController(IConfiguration configuration, IAccessTokenService iAccessToken)
        {
            //_accessTokenService = new AccessTokenService(_configuration);
            _configuration = configuration;
            _iAccessToken = iAccessToken;
        }
        //[HttpPost, Route("SignIn")]
        //public LoginResponse SignIn([FromBody] LoginRequest request)
        //{
        //    return _accessTokenService.SignIn(request);
        //}

        [SwaggerOperation(Tags = new[] { "Login" }, Summary = "Login Web", Description = "เข้าสู่ระบบเว็บไซต์")]
        [HttpPost("Login")]
        public async Task<MessageResponseModel> Login([FromBody] LoginRequest request)
        {
            MessageResponseModel msgResult = new MessageResponseModel();
            msgResult.Code = ReturnCode.SYSTEM_ERROR;
            msgResult.Message = ReturnMessage.SYSTEM_ERROR;
            msgResult.Success = false;

            try
            {
                var result = await _iAccessToken.CheckerLoginService(request);
                msgResult.Code = result.Code;
                msgResult.Message = result.Message;
                msgResult.Success = result.Success;
                msgResult.Data = result.Data;
            }
            catch (Exception ex)
            {
                msgResult.Message = ex.Message;
            }

            return msgResult;
        }
    }
}

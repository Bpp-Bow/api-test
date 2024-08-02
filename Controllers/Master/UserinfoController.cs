using Microsoft.AspNetCore.Mvc;
using N_Health_API.Models.Master;
using Microsoft.AspNetCore.Authorization;
using Microsoft.Net.Http.Headers;
using N_Health_API.Models.Shared;
using Swashbuckle.AspNetCore.Annotations;
using System.Security;
using N_Health_API.Services;
using N_Health_API.ServicesInterfece.Master;
using N_Health_API.ServicesInterfece;
using N_Health_API.ServicesInterfece.Shared;

namespace N_Health_API.Controllers
{
    [Authorize]
    [Route("Userinfo")]
    [SwaggerTag("ระบบจัดการข้อมูลผู้ใช้")]
    public class UserinfoController : Controller
    {
        private readonly IUserinfoService _iUserInfo;
        private readonly IAccessTokenService _auth;

        public UserinfoController(IUserinfoService iUserInfo, IAccessTokenService _auth)
        {
            this._auth = _auth;
            this._iUserInfo = iUserInfo;
        }

        [HttpPost, Route("List")]
        public UserinfoResponse List([FromBody] UserinfoRequest request)
        {
            var result = new UserinfoResponse();
            result.Message = "Request " + request.User_Name + " Success";
            return result;
        }

        [SwaggerOperation(Tags = new[] { "User" }, Summary = "เพิ่มข้อมูลผู้ใช้", Description = "เพิ่มข้อมูลผู้ใช้งานระบบ")]
        [HttpPost("Add")]
        public async Task<MessageResponseModel> Add([FromBody] UserinfoModel model)
        {
            MessageResponseModel msgResult = new MessageResponseModel();
            msgResult.Code = ReturnCode.SYSTEM_ERROR;
            msgResult.Message = ReturnMessage.SYSTEM_ERROR;
            msgResult.Success = false;

            try
            {
                //----------------validation header--------------------------
                string? user_code = Request.Headers["UserCode"];              
                var checkAuth_RES = await _auth.CheckAuthService(Request.Headers[HeaderNames.Authorization], user_code);
                if (!checkAuth_RES.Success)
                {
                    return checkAuth_RES;
                }

                var result = await _iUserInfo.AddService(model, user_code);
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

        [SwaggerOperation(Tags = new[] { "User" }, Summary = "แก้ไขข้อมูลผู้ใช้", Description = "แก้ไขข้อมูลผู้ใช้งานระบบ")]
        [HttpPost("Edit")]
        public async Task<MessageResponseModel> Edit([FromBody] UserinfoModel model)
        {
            MessageResponseModel msgResult = new MessageResponseModel();
            msgResult.Code = ReturnCode.SYSTEM_ERROR;
            msgResult.Message = ReturnMessage.SYSTEM_ERROR;
            msgResult.Success = false;

            try
            {
                //----------------validation header--------------------------
                string? user_code = Request.Headers["UserCode"];
                var checkAuth_RES = await _auth.CheckAuthService(Request.Headers[HeaderNames.Authorization], user_code);
                if (!checkAuth_RES.Success)
                {
                    return checkAuth_RES;
                }

                var result = await _iUserInfo.EditService(model, user_code);
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

        [SwaggerOperation(Tags = new[] { "User" }, Summary = "เปลี่ยนสถานะข้อมูล", Description = "เปลี่ยนสถานะข้อมูล Active(true) กับ Inactive(false)")]
        [HttpPost("ChangeActive")]
        public async Task<MessageResponseModel> ChangeActive([FromBody] PermissionRequest request)
        {
            MessageResponseModel msgResult = new MessageResponseModel();
            msgResult.Code = ReturnCode.SYSTEM_ERROR;
            msgResult.Message = ReturnMessage.SYSTEM_ERROR;
            msgResult.Success = false;

            try
            {

                //----------------validation header--------------------------
                string? user_code = Request.Headers["UserCode"];
                var checkAuth_RES = await _auth.CheckAuthService(Request.Headers[HeaderNames.Authorization], user_code);
                if (!checkAuth_RES.Success)
                {
                    return checkAuth_RES;
                }

                var result = await _iUserInfo.ChangeActiveService(request.Permission_Id, request.Active, user_code);
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

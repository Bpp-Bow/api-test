using Microsoft.IdentityModel.Tokens;
using N_Health_API.Models;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;
using N_Health_API.RepositoriesInterface.Master;
using N_Health_API.RepositoriesInterface.Shared;
using N_Health_API.ServicesInterfece.Shared;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Newtonsoft.Json;

namespace N_Health_API.Services
{
    public class AccessTokenService : IAccessTokenService
    {
        private readonly byte[] _secretKey;
        private readonly int _tokenExpireDate;
        private readonly IConfiguration _configuration;
        private IAuthenRepository _repo;

        public AccessTokenService(IConfiguration configuration, IAuthenRepository repo)
        {
            _secretKey = Encoding.ASCII.GetBytes("SecretkeyOfLogisboy&N-Health2024");
            _tokenExpireDate = 1;
            _configuration = configuration;
            _repo = repo;
        }
        public LoginResponse SignIn(LoginRequest request)
        {
            var result = new LoginResponse();
            var username = request.Username;
            var password = request.Password;

            result.Username = username;
            result.Token = GenerateAccessToken(username,"");
            return result;
        }

        private string GenerateAccessToken(string userName,string userCode)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.UserData, userName),
                    new Claim("user_code", userCode)
                }),
                Expires = DateTime.UtcNow.AddDays(_tokenExpireDate),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(_secretKey), SecurityAlgorithms.HmacSha256)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public async Task<MessageResponseModel> CheckAuthService(string? token, string? userCode)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                if (string.IsNullOrEmpty(userCode))
                {
                    meg_res.Success = false;
                    meg_res.Code = ReturnCode.SYSTEM_ERROR;
                    meg_res.Message = "UserCode from header can't null or empty.Please Enter";
                }
                else
                {
                    //decode token and get user_code
                    string? tAuthHeader = token?.Replace("Bearer ", "");
                    var payload = new JwtSecurityToken(tAuthHeader);
                    var user_code = payload.Claims.First(p => p.Type == "user_code").Value;

                    if (string.IsNullOrEmpty(user_code) || !userCode.Equals(user_code))
                    {
                        meg_res.Success = false;
                        meg_res.Code = ReturnCode.DATA_NOT_MATCH; 
                        meg_res.Message = string.Format("UserCode({0}.Equals({1})) not matching.Please check", userCode, user_code);

                    }
                    else
                    {
                        meg_res.Success = true;
                        meg_res.Code = ReturnCode.SUCCESS;
                        meg_res.Message = ReturnMessage.SUCCESS;
                    }


                }
                return meg_res;
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
                return meg_res;
            }
        }

        public async Task<MessageResponseModel> CheckerLoginService(LoginRequest data)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;
            try
            {
                //query
                MessageResponseModel? resUser = await _repo.CheckerLogin(data.Username);
                if (!resUser.Success)
                {
                    meg_res.Message = resUser.Message;
                    return meg_res;
                }

                if (resUser.Data == null)
                {
                    meg_res.Message = "ชื่อบัญชีผู้ใช้งานหรือรหัสผ่านไม่ถูกต้อง กรุณาลองใหม่อีกครั้ง";
                    return meg_res;
                }
                else
                {
                    //UserinfoModel? userModel = JsonConvert.DeserializeObject<UserinfoModel>(resUser?.Data?.ToString());
                    UserinfoModel? userModel = (UserinfoModel?)(resUser?.Data);
                    bool checkLogin = BCrypt.Net.BCrypt.Verify(data.Password, userModel?.Password);//เช็คเทียบ Password ที่กรอกมากับ db

                    if (!checkLogin)
                    {
                        meg_res.Message = "รหัสผ่านไม่ถูกต้อง กรุณาลองใหม่อีกครั้ง";
                        return meg_res;
                    }

                    var loginResp = new LoginResponse();

                    //loginResp.Username = username;
                    loginResp.UserCode = userModel?.User_Code;
                    loginResp.Token = GenerateAccessToken(data.Username, userModel?.User_Code);

                    meg_res.Success = true;
                    meg_res.Message = ReturnMessage.SUCCESS;
                    meg_res.Code = ReturnCode.SUCCESS;
                    meg_res.Data = loginResp;
                }
                
                
            }
            catch (Exception ex)
            {
                meg_res.Message = ex.Message + " - " + ex.StackTrace;
            }

            return meg_res;
        }
        
        private ClaimsPrincipal? GetPrincipalFromExpiredToken(string? token)
        {
            var tokenValidationParameters = new TokenValidationParameters
            {
                ValidateAudience = false,//ตรวจสอบความถูกต้องของผู้ชม
                ValidateIssuer = false,//ตรวจสอบผู้ออก
                ValidateIssuerSigningKey = true,//ตรวจสอบคีย์การลงนามผู้ออก
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(_configuration["AppSettings:JWT:Secret"])),
                ValidateLifetime = true //ตรวจสอบอายุการใช้งาน
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out SecurityToken securityToken);
            if (securityToken is not JwtSecurityToken jwtSecurityToken || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase))
                throw new SecurityTokenException("Invalid token");

            return principal;
        }
    }
}

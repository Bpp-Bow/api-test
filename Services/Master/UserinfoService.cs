using N_Health_API.Helper;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;
using N_Health_API.RepositoriesInterface;
using N_Health_API.RepositoriesInterface.Master;
using N_Health_API.ServicesInterfece.Master;

namespace N_Health_API.Services
{
    public class UserinfoService : IUserinfoService
    {
        private IConfiguration _config;
        private IUserinfoData _repo;
        public UserinfoService(IConfiguration config, IUserinfoData repo)
        {
            //_db = db;
            _config = config;
            _repo = repo;

        }

        public async Task<MessageResponseModel> AddService(UserinfoModel data, string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try
            {
                //เช็คเบอร์โทร ต้องมี 10 หลัก แล้วเอาแค่ 4 หลักสุดท้ายมาทำรหัสผ่าน
                string? tel = data?.Telephone_No?.Trim();
                int length = tel.Length;
                if (length == 10)
                {
                    string val = tel.Substring(6, 4); //เอาตัวเลขจากเบอร์โทร 4 หลักสุดท้ายมาทำรหัสผ่าน 
                    string? passWord = BCrypt.Net.BCrypt.HashPassword(val);// Default รหัสผ่าน เป็นเบอร์โทรหลัก
                    data.Password = passWord;
                    var result = await _repo.Add(data, userName);
                    if (result != false)
                    {
                        meg_res.Success = true;
                        meg_res.Message = ReturnMessage.SUCCESS;
                        meg_res.Code = ReturnCode.SUCCESS;
                        meg_res.Data = result;
                    }
                }
                else 
                {
                    meg_res.Success = false;
                    meg_res.Message = ReturnMessage.INVALID_DATA_TYPE + " เบอร์โทร ต้องมี 10 หลัก";
                    meg_res.Code = ReturnCode.INVALID_DATA_TYPE;
                    return meg_res;
                }
                

                
            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }
            return meg_res;
        }

        public async  Task<MessageResponseModel> ChangeActiveService(int id, bool isActive, string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try
            {
                var result = await _repo.ChangeActive(id, isActive, userName);

                meg_res.Success = true;
                meg_res.Message = ReturnMessage.SUCCESS;
                meg_res.Code = ReturnCode.SUCCESS;
                meg_res.Data = result;
            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }
            return meg_res;
        }

        public async Task<MessageResponseModel> CheckUserByUserNameService(string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;
            try
            {

                var data = await _repo.CheckUserByUserName(userName);

                meg_res.Success = true;
                meg_res.Message = ReturnMessage.SUCCESS;
                meg_res.Code = ReturnCode.SUCCESS;
                meg_res.Data = data;
            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }

            return meg_res;
        }

        public async Task<MessageResponseModel> EditService(UserinfoModel data, string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try
            {
                var result = await _repo.Edit(data, userName);
                if (result != false)
                {
                    meg_res.Success = true;
                    meg_res.Message = ReturnMessage.SUCCESS;
                    meg_res.Code = ReturnCode.SUCCESS;
                    meg_res.Data = result;
                }
            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }
            return meg_res;
        }

        public Task<MessageResponseModel> GetByIdService(int id)
        {
            throw new NotImplementedException();
        }

        public Task<MessageResponseModel> SearchService(SearchPermissionModel data)
        {
            throw new NotImplementedException();
        }
    }
}

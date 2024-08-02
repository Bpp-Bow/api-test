using Microsoft.Extensions.Options;
using N_Health_API.Core;
using N_Health_API.Helper;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;
using N_Health_API.RepositoriesInterface.Master;
using N_Health_API.ServicesInterfece.Master;
using System.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace N_Health_API.Services.Master
{
    public class PermissionService : IPermissionService
    {
        private IConfiguration _config;
        //private readonly DBSQLPostgre _db;
        private IPermissionData _repo;
        public PermissionService( IConfiguration config, IPermissionData repo)
        {
            //_db = db;
            _config = config;
            _repo = repo;

        }
        public async Task<MessageResponseModel> AddService(PermissionDataModel data, string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try
            {
                //เช็คข้อมูลก่อน Insert ถ้า return true ถือว่ามีข้อมูลซ้ำ
                var checkDup = await _repo.CheckDupDataPermission(data.Permission);
                if (!Convert.ToBoolean(checkDup?.Data))//ไม่ซ้ำ
                {
                    var result = await _repo.Add(data, userName);
                    if (result != false)
                    {
                        meg_res.Success = true;
                        meg_res.Message = ReturnMessage.SUCCESS;
                        meg_res.Code = ReturnCode.SUCCESS;
                        meg_res.Data = result;
                    }
                }
                else //พบข้อมูลซ้ำ
                {
                    meg_res.Success = false;
                    meg_res.Message = string.Format(ReturnMessage.DUPLICATE_DATA,checkDup.Message);
                    meg_res.Code = ReturnCode.DUPLICATE_DATA;
                }
                
            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }
            return meg_res;
        }

        public async Task<MessageResponseModel> EditService(PermissionDataModel data, string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try
            {
                //เช็คข้อมูลก่อน Insert ถ้า return true ถือว่ามีข้อมูลซ้ำ
                var checkDup = await _repo.CheckDupDataPermission(data.Permission);
                if (!Convert.ToBoolean(checkDup?.Data))//ไม่ซ้ำ
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
                else //พบข้อมูลซ้ำ
                {
                    meg_res.Success = false;
                    meg_res.Message = string.Format(ReturnMessage.DUPLICATE_DATA, checkDup.Message);
                    meg_res.Code = ReturnCode.DUPLICATE_DATA;
                }

            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }
            return meg_res;
        }

        public async Task<MessageResponseModel> GetByIdService(int id)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;
            try 
            {

                var res = await _repo.GetPermissionById(id);//data main
                //List<PermissionModel> list = res.AsEnumerable().Cast<PermissionModel>().ToList();
                //PermissionModel? d = res?.AsEnumerable()?.Cast<PermissionModel>().First();
                //map data json for fontend
                PermissionDataModel data = new PermissionDataModel();
                data.Permission.Permission_Id = Convert.ToInt32(res?.Rows[0]["permission_id"]);
                data.Permission.Permission_Code = res?.Rows[0]["permission_code"].ToString();
                data.Permission.Permission_Name = res?.Rows[0]["permission_name"].ToString();
                data.Permission.Location_Id = Convert.ToInt32(res?.Rows[0]["location_id"]);
                data.Permission.Team = res?.Rows[0]["team"].ToString();
                data.Permission.Active = Convert.ToBoolean(res?.Rows[0]["active"]);
                data.Permission.Created_By = res?.Rows[0]["created_by"].ToString();
                data.Permission.Created_DateTime = Convert.ToDateTime(res?.Rows[0]["created_datetime"]);
                data.Permission.Modified_By = res?.Rows[0]["modified_by"].ToString();
                data.Permission.Modified_DateTime = Convert.ToDateTime(res?.Rows[0]["modified_datetime"]);

                var resMenu = await _repo.GetMenuByPermissionId(id);//data list menu
                data.PermissionMenuList  = MapMenuList(resMenu);//maping menu format json fontend

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

        public async Task<MessageResponseModel> SearchService(SearchPermissionModel? data)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;
            try
            {

                var res =  Util.ConvertDataTableToList<PermissionModel>(await _repo.Search(data));
                meg_res.Success = true;
                meg_res.Message = ReturnMessage.SUCCESS;
                meg_res.Code = ReturnCode.SUCCESS;
                meg_res.Data = res;
            }
            catch (Exception ex)
            {
                meg_res.Message = methodName + " - " + ex.Message + " - " + ex.StackTrace;
            }

            return meg_res;
        }

        public  List<MenuGroupModel> MapMenuList(DataTable dt)
        {
            List<MenuGroupModel> dataList = new List<MenuGroupModel>();
            
            try
            {

                //grouping menu
                var menuGroup = from d in dt.AsEnumerable()
                                group d by d.Field<int>("menu_group_id") into g
                                select new { g.Key, Count = g.Count() };

                foreach (var group in menuGroup) 
                {
                    var list = dt.AsEnumerable().Where(x => x.Field<int>("menu_group_id") == group.Key).ToList();
                    MenuGroupModel data = new MenuGroupModel();
                    data.menu_id = Convert.ToInt32(list?[0]["menu_group_id"]);
                    data.menu_group = list?[0]["menu_group_name"].ToString();
                    //data.parent_menu_id = Convert.ToInt32(list?[0]["menu_id"]);
                    data.sequence = Convert.ToInt32(list?[0]["mg_sequence"]);
                    data.menu_name = list?[0]["menu_name"].ToString();
                    data.url = list?[0]["mg_url"].ToString();
                    data.icon = list?[0]["mg_icon"].ToString();

                    List<MenuNameModel> menuList = new List<MenuNameModel>();
                    foreach (var item in list) 
                    {
                        MenuNameModel menu = new MenuNameModel();
                        menu.menu_id = Convert.ToInt32(item?["menu_id"]);
                        menu.menu_group = item?["menu_group_name"].ToString();
                        menu.parent_menu_id = Convert.ToInt32(item?["menu_group_id"]);
                        menu.sequence = Convert.ToInt32(item?["mn_sequence"]);
                        menu.menu_name = item?["menu_name"].ToString();
                        menu.url = item?["mn_url"].ToString();
                        menu.icon = item?["mn_icon"].ToString();
                        try //try catch กรณีข้อมูล DataTable ไม่มีฟิลด์ view_flag, edit_flag
                        {
                            menu.view_flag = Convert.ToBoolean(item?["view_flag"]);
                            menu.edit_flag = Convert.ToBoolean(item?["edit_flag"]);
                        }
                        catch 
                        {
                            //ทำต่อ
                            menu.view_flag = false;
                            menu.edit_flag = false;
                        }

                        menuList.Add(menu);//add menu by record
                    }
                    data.children = menuList;//Add MenuList  

                    dataList.Add(data);//Add MenuGroup หลัก และ sub Menu ย่อย
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return dataList;
        }

        public async Task<MessageResponseModel> GetAllMenuNameService()
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try {
                var resMenu = await _repo.GetAllMenuName();//data list menu
                List<MenuGroupModel> data = MapMenuList(resMenu);//maping menu format json fontend

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

        public async Task<MessageResponseModel> ChangeActiveService(int id, bool isActive, string? userName)
        {
            string methodName = Util.GetMethodName();
            MessageResponseModel meg_res = new MessageResponseModel();
            meg_res.Message = ReturnMessage.SYSTEM_ERROR;
            meg_res.Code = ReturnCode.SYSTEM_ERROR;
            meg_res.Success = false;

            try
            {
                var result = await _repo.ChangeActive(id,isActive,userName);

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
    }
}

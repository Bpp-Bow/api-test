using N_Health_API.Core;
using N_Health_API.Helper;
using N_Health_API.Models;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;
using N_Health_API.RepositoriesInterface.Master;
using Npgsql;
using NpgsqlTypes;
using System.Data;
using System.Xml.Linq;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace N_Health_API.Repositories.Master
{
    public class PermissionData : IPermissionData
    {
        private IConfiguration _config;
        
        public PermissionData(IConfiguration config)
        {
            //_db = db;
            _config = config;

        }

        public async Task<bool> Add(PermissionDataModel? data, string? userName)
        {
            bool result = false;
            DateTime dateTime = new DateTimeUtils().NowDateTime();
            try
            {
                var qPermission = "INSERT INTO \"permission\" " +
                    "(permission_code, permission_name, location_id, team, active, created_by, created_datetime, modified_by, modified_datetime) " +
                    "VALUES(@permission_code, @permission_name, @location_id, @team, @active, @created_by, @created_datetime, @modified_by, @modified_datetime);\r\n";

                List<DBParameter> parameters = new List<DBParameter>();
                parameters.Add(new DBParameter { Name = "permission_name", Value = data?.Permission?.Permission_Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "location_id", Value = data?.Permission?.Location_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "team", Value = data?.Permission?.Team, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "active", Value = data?.Permission?.Active, Type = NpgsqlDbType.Boolean });
                parameters.Add(new DBParameter { Name = "created_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "created_datetime", Value = dateTime, Type = NpgsqlDbType.Timestamp });
                parameters.Add(new DBParameter { Name = "modified_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "modified_datetime", Value = dateTime, Type = NpgsqlDbType.Timestamp });
                parameters.Add(new DBParameter { Name = "permission_id", Value = data?.Permission?.Permission_Id, Type = NpgsqlDbType.Integer });

                string qPerm_Menu = string.Empty;
                foreach (var item in data?.PermissionMenuList)
                {
                    var query = "INSERT INTO permission_menu " +
                        "(permission_id, menu_id, view_flag, edit_flag, created_by, created_datetime, modified_by, modified_datetime) " +
                        "VALUES({0},{1}, {2}, {3}, '{4}', '{5}', '{6}', '{7}');\r\n";
                    query = string.Format(query,  data?.Permission?.Permission_Id, item.menu_id, item.view_flag, item.edit_flag, userName, dateTime ,userName ,dateTime);

                    qPerm_Menu = qPerm_Menu + query;
                }

                result = DBSQLPostgre.SQLPostgresExecutionCommand(qPermission + qPerm_Menu, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Edit(PermissionDataModel? data, string? userName)
        {
            bool result = false;
            DateTime dateTime = new DateTimeUtils().NowDateTime();
            try
            {


                var qPermission = "  UPDATE \"permission\"     " +
                            "SET  permission_name = @permission_name" +
                            ", location_id = @location_id" +
                            ", team = @team " +
                            ", active = @active " +
                            ", created_by = @created_by, created_datetime= @created_datetime  " +
                            ", modified_by = @modified_by, modified_datetime = @modified_datetime  " +
                            " where pm.permission_id = @permission_id;\r\n";

                List<DBParameter> parameters = new List<DBParameter>();
                parameters.Add(new DBParameter { Name = "permission_name", Value = data?.Permission?.Permission_Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "location_id", Value = data?.Permission?.Location_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "team", Value = data?.Permission?.Team, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "active", Value = data?.Permission?.Active, Type = NpgsqlDbType.Boolean });
                parameters.Add(new DBParameter { Name = "modified_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "modified_datetime", Value = dateTime, Type = NpgsqlDbType.Timestamp });
                parameters.Add(new DBParameter { Name = "permission_id", Value = data?.Permission?.Permission_Id, Type = NpgsqlDbType.Integer });

                string qPerm_Menu =    string.Empty;
                foreach (var item in data.PermissionMenuList ) 
                {
                    var query = "UPDATE permission_menu " +
                    "SET view_flag = {0}" +
                    ", edit_flag = {1}" +
                    ", modified_by = '{2}'" +
                    ", modified_datetime = '{3}'" +
                    "WHERE permission_id = {4}  AND menu_id = {5};\r\n";
                    query = string.Format(query, item.view_flag, item.edit_flag, data, userName, dateTime, item.menu_id, data?.Permission?.Permission_Id);

                    qPerm_Menu = qPerm_Menu + query;
                }
                
                result = DBSQLPostgre.SQLPostgresExecutionCommand(qPermission + qPerm_Menu, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<PermissionModel>> GetAll()
        {
            throw new NotImplementedException();
        }

        public async Task<DataTable> GetPermissionById(int id)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var query = "select pm.*" +
                            " from permission pm " +  
                            " where pm.permission_id = {0}";

                query = string.Format(query,id);

                var result = DBSQLPostgre.SQLPostgresSelectCommand(query);

                //var conn = new NpgsqlConnection(connString);
                //await using var cmd = new NpgsqlCommand(query, conn);
                ////await cmd.ExecuteNonQueryAsync();
                //await using var reader = await cmd.ExecuteReaderAsync();

                
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataTable> GetMenuByPermissionId(int id)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var query = "select pm.*" +
                            ",mn.menu_name,mn.url as mn_url,mn.icon as mn_icon,mn.\"sequence\" as mn_sequence" +
                            ",mg.menu_group_id ,mg.menu_group_name,mg.url as mg_url,mg.icon as mg_icon,mg.\"sequence\" as mg_sequence " +
                            " from permission_menu pm " +
                            " left join menu_name mn on pm.menu_id = mn.menu_id" +
                            " left join menu_group mg on mn.menu_group_id = mg.menu_group_id " +
                            " where pm.permission_id = {0}";

                query = string.Format(query, id);

                var result = DBSQLPostgre.SQLPostgresSelectCommand(query);


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataTable> Search(SearchPermissionModel? data)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var query = "select permission_id" +
                    ", permission_code" +
                    ", permission_name" +
                    ", location_id" +
                    ", team" +
                    ", active" +
                    ", created_by" +
                    ", created_datetime" +
                    ", modified_by" +
                    ", modified_datetime " +
                    " from permission  ";
                string condition = string.Empty;
                if (data?.Active != null) 
                {
                    condition = string.Format(condition + " active = {0}",data.Active);
                }
                if (!string.IsNullOrEmpty(data?.Team)) 
                {
                    if (!string.IsNullOrEmpty(condition))
                    {
                        condition = condition + " and ";
                    }
                    condition = string.Format(condition + " team = '{0}'", data.Team);
                }
                if (!string.IsNullOrEmpty(data?.Permission_Name)) 
                {
                    if (!string.IsNullOrEmpty(condition))
                    {
                        condition = condition + " and ";
                    }
                    condition = string.Format(condition + " permission_name like '%{0}%'", data.Permission_Name);
                }

                if (!string.IsNullOrEmpty(condition)) 
                {
                    query = query + " where "+ condition;
                }


                var result = DBSQLPostgre.SQLPostgresSelectCommand(query);

                //var conn = new NpgsqlConnection(connString);
                //await using var cmd = new NpgsqlCommand(query, conn);
                ////await cmd.ExecuteNonQueryAsync();
                //await using var reader = await cmd.ExecuteReaderAsync();


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<DataTable> GetAllMenuName()
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var query = "select mn.menu_id,mn.menu_name,mn.menu_name,mn.url as mn_url,mn.icon as mn_icon,mn.\"sequence\" as mn_sequence " +
                    ",mg.menu_group_id ,mg.menu_group_name,mg.url as mg_url,mg.icon as mg_icon,mg.\"sequence\" as mg_sequence " +
                    " from menu_name mn " +
                    " left join menu_group mg on mn.menu_group_id = mg.menu_group_id";

                query = string.Format(query);

                var result = DBSQLPostgre.SQLPostgresSelectCommand(query);


                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> ChangeActive(int id, bool isActive,string? userName)
        {
            try
            {
                var query = "  UPDATE \"permission\"     " +
                            "   SET active = @active  " +
                            ", modified_by = @modified_by " +
                            ", modified_datetime = @modified_datetime  " +
                            " where pm.permission_id = @permission_id";

                query = string.Format(query, id);

                List<DBParameter> parameters = new List<DBParameter>();
                parameters.Add(new DBParameter { Name = "active", Value = isActive, Type = NpgsqlDbType.Boolean });
                parameters.Add(new DBParameter { Name = "modified_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "modified_datetime", Value = new DateTimeUtils().NowDateTime(), Type = NpgsqlDbType.Timestamp });
                parameters.Add(new DBParameter { Name= "permission_id" ,Value = id, Type = NpgsqlDbType.Integer });

                var res = DBSQLPostgre.SQLPostgresExecutionCommand(query, parameters);               
                return res;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<MessageResponseModel> CheckDupDataPermission(PermissionModel? data)
        {
            MessageResponseModel meg_res = new MessageResponseModel();
            try
            {
                var query = "select p.*" +
                            " from permission p " +
                            " where p.permission_name = '{0}'";

                query = string.Format(query, data?.Permission_Name);

                var result = DBSQLPostgre.SQLPostgresSelectCommand(query);
                if (result != null && result?.AsEnumerable().Count() > 0) 
                {
                    meg_res.Success = true;
                    meg_res.Message = string.Format("(User Rolse : {0})", data?.Permission_Name);
                    meg_res.Code = ReturnCode.DUPLICATE_DATA;
                    meg_res.Data = true;//data เป็น true ให้ถือว่าเจอข้อมูลซ้ำ
                    return meg_res;
                }
                else
                {
                    meg_res.Success = true;
                    meg_res.Message = ReturnMessage.SUCCESS;
                    meg_res.Code = ReturnCode.SUCCESS;
                    meg_res.Data = false;//data เป็น false ให้ถือว่าข้อมูลไม่ซ้ำ
                    return meg_res;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }
    }
}

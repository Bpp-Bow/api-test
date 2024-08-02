using N_Health_API.Core;
using N_Health_API.Helper;
using N_Health_API.Models;
using N_Health_API.Models.Master;
using N_Health_API.Models.Shared;
using N_Health_API.RepositoriesInterface.Master;
using N_Health_API.ServicesInterfece;
using NpgsqlTypes;

namespace N_Health_API.Repositories.Master
{
    public class UserinfoData : IUserinfoData
    {
        public async Task<bool> Add(UserinfoModel data, string userName)
        {
            bool result = false;
            DateTime dateTime = new DateTimeUtils().NowDateTime();
            try
            {
                var qUser = "INSERT INTO userinfo " +
                    "(user_id, user_code, \"password\", user_name, employee_id" +
                    ", prefix_name, \"name\", lastname" +
                    ", user_type, user_level, team" +
                    ", telephone_no, email" +
                    ", location_id, department_id, permission_id" +
                    ", active, created_by, created_datetime, modified_by, modified_datetime) " +
                    "VALUES(@user_id ,@user_code ,@password ,@user_name ,@employee_id " +
                    ",@prefix_name ,@name ,@lastname " +
                    ",@user_type ,@user_level ,@team " +
                    ",@telephone_no ,@email " +
                    ",@location_id ,@department_id ,@permission_id " +
                    ",@active ,@created_by ,@created_datetime ,@modified_by ,@modified_datetime);\r\n";

                List<DBParameter> parameters = new List<DBParameter>();
                parameters.Add(new DBParameter { Name = "user_id", Value = data?.User_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "user_code", Value = data?.User_Code, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "password", Value = data?.Password, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "user_name", Value = data?.User_Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "employee_id", Value = data?.Employee_Id, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "prefix_name", Value = data?.Prefix_Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "name", Value = data?.Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "lastname", Value = data?.Lastname, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "user_type", Value = data?.User_Type, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "user_level", Value = data?.User_Level, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "team", Value = data?.Team, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "telephone_no", Value = data?.Telephone_No, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "email", Value = data?.Email, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "location_id", Value = data?.Location_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "department_id", Value = data?.Department_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "permission_id", Value = data?.Permission_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "active", Value = data?.Active, Type = NpgsqlDbType.Boolean });
                parameters.Add(new DBParameter { Name = "created_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "created_datetime", Value = dateTime, Type = NpgsqlDbType.Timestamp });
                parameters.Add(new DBParameter { Name = "modified_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "modified_datetime", Value = dateTime, Type = NpgsqlDbType.Timestamp });
                                
                result = DBSQLPostgre.SQLPostgresExecutionCommand(qUser, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<bool> ChangeActive(int id, bool isActive, string userName)
        {
            throw new NotImplementedException();
        }

        public async Task<UserinfoModel> CheckUserByUserName(string userName)
        {
            UserinfoModel result = new UserinfoModel();

            try
            {
                var query = "SELECT user_id, user_code, \"password\", user_name, employee_id, prefix_name, \"name\", lastname " +
                        " FROM userinfo " +
                        " where user_name = '{0}'";

                query = string.Format(query, userName);

                var res = DBSQLPostgre.SQLPostgresSelectCommand(query);

                result.User_Id = Convert.ToInt32(res?.Rows[0]["user_id"]);
                result.User_Code = res?.Rows[0]["user_code"].ToString();
                result.Password = res?.Rows[0]["password"].ToString();
                result.Employee_Id = res?.Rows[0]["employee_id"].ToString();
                result.Prefix_Name = res?.Rows[0]["prefix_name"].ToString();
                result.Name = res?.Rows[0]["name"].ToString();
                result.Lastname = res?.Rows[0]["lastname"].ToString();
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> Edit(UserinfoModel? data, string userName)
        {

            bool result = false;
            DateTime dateTime = new DateTimeUtils().NowDateTime();
            try
            {
                var qUser = "UPDATE userinfo " +
                    "SET user_code=@user_code, user_name=@user_name, employee_id=@employee_id" +
                    ", prefix_name=@prefix_name, \"name\"=@name, lastname=@lastname" +
                    ", user_type=@user_type, user_level=@user_level, team=@team, telephone_no=@telephone_no, email=@email" +
                    ", location_id=@location_id, department_id=@department_id, permission_id=@permission_id, active=@active" +
                    ", modified_by=@modified_by, modified_datetime=@modified_datetime WHERE user_id=@user_id;\r\n";

                List<DBParameter> parameters = new List<DBParameter>();
                parameters.Add(new DBParameter { Name = "user_id", Value = data?.User_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "user_code", Value = data?.User_Code, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "user_name", Value = data?.User_Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "employee_id", Value = data?.Employee_Id, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "prefix_name", Value = data?.Prefix_Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "name", Value = data?.Name, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "lastname", Value = data?.Lastname, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "user_type", Value = data?.User_Type, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "user_level", Value = data?.User_Level, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "team", Value = data?.Team, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "telephone_no", Value = data?.Telephone_No, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "email", Value = data?.Email, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "location_id", Value = data?.Location_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "department_id", Value = data?.Department_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "permission_id", Value = data?.Permission_Id, Type = NpgsqlDbType.Integer });
                parameters.Add(new DBParameter { Name = "active", Value = data?.Active, Type = NpgsqlDbType.Boolean });
                parameters.Add(new DBParameter { Name = "modified_by", Value = userName, Type = NpgsqlDbType.Varchar });
                parameters.Add(new DBParameter { Name = "modified_datetime", Value = dateTime, Type = NpgsqlDbType.Timestamp });

                result = DBSQLPostgre.SQLPostgresExecutionCommand(qUser, parameters);
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}

using N_Health_API.Models.Shared;

namespace N_Health_API.Models.Master
{
    public class UserinfoRequest
    {
        public int User_Id { get; set; }
        public string User_Code { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string User_Name { get; set; } = string.Empty;
        public string Employee_Id { get; set; } = string.Empty;
        public string Prefix_Name { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string User_Type { get; set; } = string.Empty;
        public int User_Level { get; set; }
        public string Team { get; set; } = string.Empty;
        public string Telephone_No { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public int Department_Id { get; set; }
        public int Permission_Id { get; set; }
        public bool Active { get; set; }
    }

    public class UserinfoResponse : MasterResponse
    {
        public IEnumerable<UserinfoModel> Data { get; set; } = [];
    }

    public class UserinfoModel : MasterModel
    {
        public int User_Id { get; set; }
        public string? User_Code { get; set; } = string.Empty;
        public string? Password { get; set; } = string.Empty;
        public string? User_Name { get; set; } = string.Empty;
        public string? Employee_Id { get; set; } = string.Empty;
        public string? Prefix_Name { get; set; } = string.Empty;
        public string? Name { get; set; } = string.Empty;
        public string? Lastname { get; set; } = string.Empty;
        public string? User_Type { get; set; } = string.Empty;
        public int User_Level { get; set; }
        public string? Team { get; set; } = string.Empty;
        public string? Telephone_No { get; set; } = string.Empty;
        public string? Email { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public int Department_Id { get; set; }
        public int Permission_Id { get; set; }
        public bool Active { get; set; }
    }

    public class SearchUserInfoModel : RequestParameterModel
    {
        public List<UserinfoModel>? UserinfoList { get; set; }
    }
}

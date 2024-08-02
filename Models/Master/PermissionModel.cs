using Microsoft.OpenApi.MicrosoftExtensions;
using N_Health_API.Models.Shared;

namespace N_Health_API.Models.Master
{
    public class PermissionModel : MasterModel
    {
        public int? Permission_Id { get; set; }
        public string? Permission_Code { get; set; } = string.Empty;
        public string? Permission_Name { get; set; } = string.Empty;
        public int? Location_Id { get; set; }
        public string? Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }

    public class PermissionMenuModel : MasterModel
    {
        public int Permission_Id { get; set; }
        public int Menu_Id { get; set; }
        public string Menu_Group { get; set; } = string.Empty;
        public string Menu_Name { get; set; } = string.Empty;
        public int Sequence { get; set; }
        public string Url { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public bool View_Flag { get; set; }
        public bool Edit_Flag { get; set; }
    }

    public class PermissionRequest
    {
        public int Permission_Id { get; set; }
        public bool Active { get; set; }
    }
    public class SearchPermissionModel : RequestParameterModel
    {
        public string? Permission_Name { get; set; } = string.Empty;
        public string? Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }

    public class PermissionDataModel 
    {
        public PermissionModel Permission { get; set; } = new PermissionModel();
        public List<MenuGroupModel>? PermissionMenuList { get; set; } = new List<MenuGroupModel>();

    }
    #region json respone to fontend
    public class MenuGroupModel
    {
        public int menu_id { get; set; }
        public string? menu_group { get; set; } = string.Empty;
        public int? parent_menu_id { get; set; } = null;
        public int sequence { get; set; }
        public string? menu_name { get; set; } = string.Empty;
        public string? url { get; set; } = string.Empty;
        public string? icon { get; set; } = string.Empty;
        public bool? view_flag { get; set; } = null;
        public bool? view_flag_indeterminate { get; set; } = null;
        public bool? edit_flag { get; set; } = null;
        public bool? edit_flag_indeterminate { get; set; } = null;
        public List<MenuNameModel> children { get; set; }  = new List<MenuNameModel>();
    }

    public class MenuNameModel
    {
        public int menu_id { get; set; }
        public string? menu_group { get; set; } = string.Empty;
        public int? parent_menu_id { get; set; } = null;
        public int sequence { get; set; }
        public string? menu_name { get; set; } = string.Empty;
        public string? url { get; set; } = string.Empty;
        public string? icon { get; set; } = string.Empty;
        public bool? view_flag { get; set; } = false;
        public bool? edit_flag { get; set; } = false;
    }
    #endregion
}

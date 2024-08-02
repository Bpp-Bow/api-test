namespace N_Health_API.Models.Master
{
    public class DepartmentModel : MasterModel
    {
        public int Department_Id { get; set; }
        public string Department_Code { get; set; } = string.Empty;
        public string Department_Name { get; set; } = string.Empty;
        public string Department_Qrcode { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public int Area_Id { get; set; }
        public bool Active { get; set; }
    }
}

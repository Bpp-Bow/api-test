namespace N_Health_API.Models.Master
{
    public class RouteModel : MasterModel
    {
        public int Route_Id { get; set; }
        public string Route_Code { get; set; } = string.Empty;
        public string Route_Name { get; set; } = string.Empty;
        public int Vehicle_Type_Id { get; set; }
        public int Location_Id { get; set; }
        public int Create_Type { get; set; }
        public int Origin_Department_Id { get; set; }
        public int Destination_Department_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class RouteDepartmentModel : MasterModel
    {
        public int Route_Id { get; set; }
        public int Origin_Department_Id { get; set; }
        public int Destination_Department_Id { get; set; }
    }

}

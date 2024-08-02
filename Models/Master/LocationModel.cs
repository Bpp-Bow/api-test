namespace N_Health_API.Models.Master
{
    public class LocationModel : MasterModel
    {
        public int Location_Id { get; set; }
        public string Location_Code { get; set; } = string.Empty;
        public string Location_Name { get; set; } = string.Empty;
        public string Short_Location_Name { get; set; } = string.Empty;
        public string Customer_Type { get; set; } = string.Empty;
        public string Sold_To_Code { get; set; } = string.Empty;
        public string Ship_To_Code1 { get; set; } = string.Empty;
        public string Ship_To_Code2 { get; set; } = string.Empty;
        public string Ship_To_Code3 { get; set; } = string.Empty;
        public string Ship_To_Code4 { get; set; } = string.Empty;
        public string Ship_To_Code5 { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string Postcode { get; set; } = string.Empty;
        public string District { get; set; } = string.Empty;
        public string Province { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public bool Active { get; set; }
    }
    public class LocationBuildingModel : MasterModel
    {
        public int Location_Id { get; set; }
        public int Building_Id { get; set; }
    }
}

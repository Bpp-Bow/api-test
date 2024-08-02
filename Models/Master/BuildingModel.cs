namespace N_Health_API.Models.Master
{
    public class BuildingModel : MasterModel
    {
        public int Building_Id { get; set; }
        public string Building_Code { get; set; } = string.Empty;
        public string Building_Name { get; set; } = string.Empty;
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
        public string Team { get; set; } = string.Empty;
        public int Floor_No { get; set; }
        public string Area_Code { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class AreaModel : MasterModel
    {
        public int Building_Id { get; set; }
        public int Area_Id { get; set; }
        public string Area_Code { get; set; } = string.Empty;
        public string Area_Name { get; set; } = string.Empty;
        public int Floor { get; set; }
    }
}

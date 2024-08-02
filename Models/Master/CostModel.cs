namespace N_Health_API.Models.Master
{
    public class CostModel : MasterModel
    {
        public int Cost_Id { get; set; }
        public string Cost_Code { get; set; } = string.Empty;
        public string Cost_Name { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class CostVehicleTypeModel : MasterModel
    {
        public int Cost_Id { get; set; }
        public int Vehicle_Type_Id { get; set; }
        public decimal Cost_Value { get; set; }
        public string Cost_Per_Unit_Type { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}

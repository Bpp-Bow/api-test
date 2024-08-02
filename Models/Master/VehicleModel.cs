namespace N_Health_API.Models.Master
{
    public class VehicleModel : MasterModel
    {
        public int Vehicle_Id { get; set; }
        public string Vehicle_Code { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public int Vehicle_Type_Id { get; set; }
        public string Plate_No { get; set; } = string.Empty;
        public DateTime? Contract_Start { get; set; }
        public DateTime? Contract_End { get; set; }
        public int Contract_Type { get; set; }
        public string Vendor_Name { get; set; } = string.Empty;
        public DateTime? Tax_End { get; set; }
        public DateTime? Compulsory_Insurance_End { get; set; }
        public DateTime? Insurance_End { get; set; }
        public DateTime? Calibration_End { get; set; }
        public DateTime? Gps_End { get; set; }
        public string Chassis_No { get; set; } = string.Empty;
        public decimal Fuel_Rate { get; set; }
        public bool Active { get; set; }
    }
}

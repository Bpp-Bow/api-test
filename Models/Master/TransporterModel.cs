namespace N_Health_API.Models.Master
{
    public class TransporterModel : MasterModel
    {
        public int Transporter_Id { get; set; }
        public string Transporter_Code { get; set; } = string.Empty;
        public string User_Name { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string Transporter_Image { get; set; } = string.Empty;
        public string Employee_Id { get; set; } = string.Empty;
        public string Prefix_Name { get; set; } = string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string Nickname { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public int Department_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public int Team_Unit_Id { get; set; }
        public string Permanence_Type { get; set; } = string.Empty;
        public bool Have_Motorcycle { get; set; }
        public string License_Id { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class Transporter_Motorcycle_Plate_NoModel : MasterModel
    {
        public int Transporter_Id { get; set; }
        public string Motorcycle_Plate_No { get; set; } = string.Empty;
    }
}

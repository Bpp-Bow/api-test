namespace N_Health_API.Models.Master
{
    public class NavigationModel : MasterModel
    {
        public int Navigation_Id { get; set; }
        public string Navigation_Code { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public int Building_Id { get; set; }
        public int Floor { get; set; }
        public int Main_Department_Id { get; set; }
        public bool Active { get; set; }
    }
    public class NavigationRouteModel : MasterModel
    {
        public int Navigation_Id { get; set; }
        public char Direction { get; set; }
        public int Run_No { get; set; }
        public int Origin_Department_Id { get; set; }
        public int Destination_Department_Id { get; set; }
        public int Route_Time { get; set; }
        public string Process_Message_01 { get; set; } = string.Empty;
        public string Process_Image_01 { get; set; } = string.Empty;
        public char Process_Arrow_01 { get; set; }
        public string Process_Message_02 { get; set; } = string.Empty;
        public string Process_Image_02 { get; set; } = string.Empty;
        public char Process_Arrow_02 { get; set; }
        public string Process_Message_03 { get; set; } = string.Empty;
        public string Process_Image_03 { get; set; } = string.Empty;
        public char Process_Arrow_03 { get; set; }
        public string Process_Message_04 { get; set; } = string.Empty;
        public string Process_Image_04 { get; set; } = string.Empty;
        public char Process_Arrow_04 { get; set; }
        public string Process_Message_05 { get; set; } = string.Empty;
        public string Process_Image_05 { get; set; } = string.Empty;
        public char Process_Arrow_05 { get; set; }
        public bool Active { get; set; }
    }

}

namespace N_Health_API.Models.Operation
{
    public class RequestJobModel : MasterModel
    {
        public int Request_Job_No { get; set; }
        public string Created_Type { get; set; } = string.Empty;
        public string Ref_No { get; set; } = string.Empty;
        public int Department_Id { get; set; }
        public int Jobtype_Id { get; set; }
        public string Crossborder_Delivery { get; set; } = string.Empty;
        public DateTime Operate_Date { get; set; }
        public string Appointed_Time { get; set; } = string.Empty;
        public int Priority_Id { get; set; }
        public int Jobno_Runtype_Id { get; set; }
        public bool Product_Flag { get; set; }
        public bool Route_Flag { get; set; }
        public int Origin_Location_Id { get; set; }
        public int Destination_Location_Id { get; set; }
    }

}

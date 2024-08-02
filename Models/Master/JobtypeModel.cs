namespace N_Health_API.Models.Master
{
    public class JobtypeModel : MasterModel
    {
        public int Jobtype_Id { get; set; }
        public string Jobtype_Code { get; set; } = string.Empty;
        public string Jobtype_Name { get; set; } = string.Empty;
        public string Jobtype_Desc { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public bool Product_Detail_Flag { get; set; }
        public string Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class JobtypeReasonModel : MasterModel
    {
        public int Jobtype_Id { get; set; }
        public int Reason_Id { get; set; }
    }
}

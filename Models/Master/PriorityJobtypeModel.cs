namespace N_Health_API.Models.Master
{
    public class PriorityJobtypeModel : MasterModel
    {
        public int Priority_Jobtype_Id { get; set; }
        public string Priority_Jobtype_Code { get; set; } = string.Empty;
        public int Priority_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public int Service_Time { get; set; }
        public int Waiting_Time { get; set; }
        public bool Active { get; set; }
    }
    public class PriorityJobtypeJobtypeModel : MasterModel
    {
        public int Priority_Jobtype_Id { get; set; }
        public int Jobtype_Id { get; set; }
    }
}

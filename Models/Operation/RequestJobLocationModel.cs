namespace N_Health_API.Models.Operation
{
    public class RequestJobLocationModel : MasterModel
    {
        public int Request_Job_No { get; set; }
        public int Route_Id { get; set; }
        public int Location_Id { get; set; }
        public string Location_Type { get; set; } = string.Empty;
        public string Document_Id { get; set; } = string.Empty;
        public string Hn_Id { get; set; } = string.Empty;
        public string Remark { get; set; } = string.Empty;
    }
}

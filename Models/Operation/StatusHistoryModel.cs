namespace N_Health_API.Models.Operation
{
    public class StatusHistoryModel : MasterModel
    {
        public int Status_History_Id { get; set; }
        public int Request_Job_No { get; set; }
        public int Status_Id { get; set; }
    }
}

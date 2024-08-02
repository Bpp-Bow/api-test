namespace N_Health_API.Models.Master
{
    public class ResonResponse : MasterResponse
    {
        public IEnumerable<ReasonModel> Data { get; set; } = [];
    }
    public class ReasonRequest
    {
        public int Reason_Id { get; set; }
    }
    public class ReasonModel : MasterModel
    {
        public int Reason_Id { get; set; }
        public string Reason_Code { get; set; } = string.Empty;
        public string Reason_Name { get; set; } = string.Empty;
        public bool Active { get; set; }
    }

}

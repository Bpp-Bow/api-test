namespace N_Health_API.Models
{
    public class MasterResponse
    {
        public bool Success { get; set; } = false;
        public string Message { get; set; } = string.Empty;
        public string code { get; set; }
    }

    public class MasterModel
    {
        public string? Created_By { get; set; }
        public DateTime Created_DateTime { get; set; } = DateTime.Now;
        public string? Modified_By { get; set; }
        public DateTime Modified_DateTime { get; set; } = DateTime.Now;

    }
}

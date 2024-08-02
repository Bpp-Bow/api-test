namespace N_Health_API.Models.Shared
{
    public class MessageResponseModel
    {
        public bool Success { get; set; } = false;
        public string? Message { get; set; }
        public int Code { get; set; }
        public object? Data { get; set; } = null;
    }
}

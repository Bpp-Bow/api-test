namespace N_Health_API.Models.Master
{
    public class PriorityModel : MasterModel
    {
        public int Priority_Id { get; set; }
        public string Priority_Code { get; set; } = string.Empty;
        public string Priority_Name { get; set; } = string.Empty;
        public string Priority_Color { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}

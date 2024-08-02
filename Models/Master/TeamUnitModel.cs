namespace N_Health_API.Models.Master
{
    public class TeamUnitModel : MasterModel
    {
        public int TeamUnitId { get; set; }
        public string TeamUnitCode { get; set; } = string.Empty;
        public string TeamUnitName { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}

namespace N_Health_API.Models.Master
{
    public class AssignJobModel : MasterModel
    {
        public int AssignJobId { get; set; }
        public string AssignJobCode { get; set; } = string.Empty;
        public string AssignJobName { get; set; } = string.Empty;
        public int LocationId { get; set; }
        public string Team { get; set; } = string.Empty;
        public string WorktimeStart { get; set; } = string.Empty;
        public string WorktimeEnd { get; set; } = string.Empty;
        public string BreaktimeStart { get; set; } = string.Empty;
        public string BreaktimeEnd { get; set; } = string.Empty;
        public int OtHour { get; set; }
        public bool Active { get; set; }
    }
    public class AssignJobJobTypeModel : MasterModel
    {
        public int AssignJobId { get; set; }
        public int JobtypeId { get; set; }
    }
    public class AssignJobRouteModel : MasterModel
    {
        public int AssignJobId { get; set; }
        public int AssignJobRouteId { get; set; }
        public string RouteType { get; set; } = string.Empty;
        public DateTime RoutetimeStart { get; set; }
        public DateTime RoutetimeEnd { get; set; }
        public string CreateworkType { get; set; } = string.Empty;
        public int CreateworkBuildingId { get; set; }
        public int CreateworkDepartmentId { get; set; }
        public string RepeatdateType { get; set; } = string.Empty;
        public bool RepeatdateMon { get; set; }
        public bool RepeatdateTue { get; set; }
        public bool RepeatdateWed { get; set; }
        public bool RepeatdateThu { get; set; }
        public bool RepeatdateFri { get; set; }
        public bool RepeatdateSat { get; set; }
        public bool RepeatdateSun { get; set; }
        public bool SetperiodFlag { get; set; }
        public DateTime RepeatdateStart { get; set; }
        public DateTime RepeatdateEnd { get; set; }
        public string RepeattimeType { get; set; } = string.Empty;
        public int RepeattimeMinute { get; set; }
        public int DistanceSummary { get; set; }
        public bool Active { get; set; }
    }
    public class AssignJobRouteItemModel : MasterModel
    {
        public int AssignJobId { get; set; }
        public int AssignJobRouteId { get; set; }
        public int AssignJobRouteItemId { get; set; }
        public int OriginBuildingId { get; set; }
        public int DestinationBuildingId { get; set; }
        public int OriginDepartmentId { get; set; }
        public int DestinationDepartmentId { get; set; }
        public int JobtypeId { get; set; }
        public int PriorityId { get; set; }
        public int Distance { get; set; }
        public string Remark { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class AssignJobRouteRepeatdateModel : MasterModel
    {
        public int AssignJobId { get; set; }
        public int AssignJobRouteId { get; set; }
        public int AssignJobRouteRepeatdateId { get; set; }
        public DateTime Repeatdate { get; set; }
        public bool Active { get; set; }
    }
    public class AssignJobRouteRepeattimeModel : MasterModel
    {
        public int AssignJobId { get; set; }
        public int AssignJobRouteId { get; set; }
        public int AssignJobRouteRepeattimeId { get; set; }
        public string RepeattimeValue { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}

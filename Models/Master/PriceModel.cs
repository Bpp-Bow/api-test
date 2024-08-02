namespace N_Health_API.Models.Master
{
    public class PriceModel : MasterModel
    {
        public int Price_Id { get; set; }
        public string Price_Code { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public int Priority_Id { get; set; }
        public int Department_Id { get; set; }
        public decimal Price_Single { get; set; }
        public decimal Price_Multi { get; set; }
        public decimal Penalty_Rate { get; set; }
        public char Penalty_Unit { get; set; }
        public bool Active { get; set; }
    }
}

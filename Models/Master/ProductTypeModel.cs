namespace N_Health_API.Models.Master
{
    public class ProductTypeModel : MasterModel
    {
        public int Product_Type_Id { get; set; }
        public string Product_Type_Code { get; set; } = string.Empty;
        public int Product_Type_Code_Interface { get; set; }
        public string Product_Type_Name { get; set; } = string.Empty;
        public bool Sub_Product_Flag { get; set; }
        public bool Active { get; set; }
    }
}

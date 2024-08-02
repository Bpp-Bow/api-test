namespace N_Health_API.Models.Master
{
    public class ProductDetailModel : MasterModel
    {
        public int Product_Detail_Id { get; set; }
        public string Product_Detail_Code { get; set; } = string.Empty;
        public string Product_Detail_Name { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
    public class ProductDetailJobtypeModel : MasterModel
    {
        public int Product_Detail_Id { get; set; }
        public int Jobtype_Id { get; set; }
    }
    public class ProductDetailProductTypeModel : MasterModel
    {
        public int Product_Detail_Id { get; set; }
        public int Product_Type_Id { get; set; }
        public bool Active { get; set; }
    }
}

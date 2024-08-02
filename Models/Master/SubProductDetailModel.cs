namespace N_Health_API.Models.Master
{
    public class SubProductDetailModel : MasterModel
    {
        public int Sub_Product_Detail_Id { get; set; }
        public string Sub_Product_Detail_Code { get; set; } = string.Empty;
        public string Sub_Product_Detail_Name { get; set; } = string.Empty;
        public string Team { get; set; } = string.Empty;
        public int Product_Type_Id { get; set; }
        public bool Active { get; set; }
    }
    public class SubProductDetailJobtypeModel : MasterModel
    {
        public int Sub_Product_Detail_Id { get; set; }
        public int Jobtype_Id { get; set; }
    }
    public class SubProductDetailProductTypeModel : MasterModel
    {
        public int Sub_Product_Detail_Id { get; set; }
        public int Product_Type_Id { get; set; }
        public bool Active { get; set; }
    }
}

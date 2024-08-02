namespace N_Health_API.Models.Shared
{
    public static class ReturnMessage
    {
        public const string REQUEST_NOT_FOUND = "ไม่พบข้อมูล Request";
        public const string REQUIRED_PARAMETER = "โปรดระบุข้อมูล";
        public const string INVALID_PARAMETER = "พารามิเตอร์ไม่ถูกต้อง";
        public const string DUPLICATE_DATA = "{0} นี้มีข้อมูลอยู่ในระบบแล้ว กรุณาตรวจสอบใหม่อีกครั้ง";
        public const string DATA_NOT_FOUND = "ไม่พบข้อมูล";
        public const string FILE_NOT_FOUND = "ไม่พบไฟล์";
        public const string INVALID_DATA_TYPE = "รูปแบบข้อมูลไม่ถูกต้อง";
        public const string DATA_NOT_MATCH = "ข้อมูล {0} ไม่ตรงกับข้อมูลที่มีอยู่ในระบบ";

        public const string SUCCESS = "สำเร็จ";
        public const string SYSTEM_ERROR = "พบข้อผิดพลาด";
    }

    public static class ReturnCode
    {

        public const int REQUEST_NOT_FOUND = 1;
        public const int REQUIRED_PARAMETER = 2;
        public const int INVALID_PARAMETER = 3;
        public const int DUPLICATE_DATA = 4;
        public const int DATA_NOT_FOUND = 5;
        public const int FILE_NOT_FOUND = 6;
        public const int INCORRECT_FILE_TYPE = 7;
        public const int INVALID_DATA_TYPE = 8;
        public const int DATA_NOT_MATCH = 9;

        public const int SUCCESS = 200;
        public const int SYSTEM_ERROR = 999;
        public const int UNAUTHORIZED = 401;
    }
}

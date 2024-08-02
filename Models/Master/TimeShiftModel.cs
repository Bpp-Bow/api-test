namespace N_Health_API.Models.Master
{
    public class TimeShiftModel : MasterModel
    {
        public int Time_Shift_Id { get; set; }
        public string Time_Shift_Code { get; set; } = string.Empty;
        public int Location_Id { get; set; }
        public string Team { get; set; } = string.Empty;
        public int Vehicle_Type_Id { get; set; }
        public string Month { get; set; } = string.Empty;
        public int Team_Unit_Id { get; set; }
        public bool Active { get; set; }
    }
    public class TimeShiftDetailInternalModel : MasterModel
    {
        public int Time_Shift_Id { get; set; }
        public string Table_Type { get; set; } = string.Empty;
        public int Employee_Id { get; set; }
        public string Employee_Code { get; set; } = string.Empty;
        public string Employee_Name { get; set; } = string.Empty;
        public int Department_Id_01 { get; set; }
        public int Department_Id_02 { get; set; }
        public int Department_Id_03 { get; set; }
        public int Department_Id_04 { get; set; }
        public int Department_Id_05 { get; set; }
        public int Department_Id_06 { get; set; }
        public int Department_Id_07 { get; set; }
        public int Department_Id_08 { get; set; }
        public int Department_Id_09 { get; set; }
        public int Department_Id_10 { get; set; }
        public int Department_Id_11 { get; set; }
        public int Department_Id_12 { get; set; }
        public int Department_Id_13 { get; set; }
        public int Department_Id_14 { get; set; }
        public int Department_Id_15 { get; set; }
        public int Department_Id_16 { get; set; }
        public int Department_Id_17 { get; set; }
        public int Department_Id_18 { get; set; }
        public int Department_Id_19 { get; set; }
        public int Department_Id_20 { get; set; }
        public int Department_Id_21 { get; set; }
        public int Department_Id_22 { get; set; }
        public int Department_Id_23 { get; set; }
        public int Department_Id_24 { get; set; }
        public int Department_Id_25 { get; set; }
        public int Department_Id_26 { get; set; }
        public int Department_Id_27 { get; set; }
        public int Department_Id_28 { get; set; }
        public int Department_Id_29 { get; set; }
        public int Department_Id_30 { get; set; }
        public int Department_Id_31 { get; set; }
        public bool Active { get; set; }
    }
    public class TimeShiftDetailExternalModel : MasterModel
    {
        public int Time_Shift_Id { get; set; }
        public string Table_Type { get; set; } = string.Empty;
        public int Employee_Id { get; set; }
        public string Employee_Code { get; set; } = string.Empty;
        public string Employee_Name { get; set; } = string.Empty;
        public int Mon_Period { get; set; }
        public int Tue_Period { get; set; }
        public int Web_Period { get; set; }
        public int Thu_Period { get; set; }
        public int Fri_Period { get; set; }
        public int Sat_Period { get; set; }
        public int Sun_Period { get; set; }
        public bool Active { get; set; }
    }
    public class PeriodTimeModel : MasterModel
    {
        public int Period_Id { get; set; }
        public string Period_Code { get; set; } = string.Empty;
        public string Period_Name { get; set; } = string.Empty;
        public string Start_Time { get; set; } = string.Empty;
        public string End_Time { get; set; } = string.Empty;
        public bool Active { get; set; }
    }
}

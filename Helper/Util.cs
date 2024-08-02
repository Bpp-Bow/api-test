using Microsoft.Extensions.Primitives;
using N_Health_API.Models.Shared;
using System.Data;
using System.Globalization;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;

namespace N_Health_API.Helper
{
    public class Util
    {
        public static bool BetweenDate(DateTime date, DateTime StartDate, DateTime EndDate)
        {
            if (StartDate <= date && date <= EndDate)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static DateTime Date(DateTime date)
        {
            DateTime dateNow;
            if (date.Year < 2000)
            {
                dateNow = Convert.ToDateTime(date.AddYears(543));
                return dateNow;
            }
            else if (date.Year > 3000)
            {
                dateNow = Convert.ToDateTime(date.AddYears(-543));
                return dateNow;
            }
            return date;
        }
        public static string ConvertDatetime(DateTime date)
        {
            string c_date = date.ToString("dd/MM/yyyy HH:mm:ss");
            return c_date;
        }
        public static DateTime ConvertStringDateFormatSAP(string date)
        {
            string iString = date;
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            DateTime oDate = DateTime.ParseExact(iString, "yyyyMMdd", Culture);
            return oDate;
        }
        public static DateTime ConvertStringDate(string date)
        {
            string iString = date;
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            DateTime oDate = DateTime.ParseExact(iString, "dd/MM/yyyy", Culture);
            return oDate;
        }
        public static string ConvertStringDateToString(string date)
        {
            DateTime tempDate = Convert.ToDateTime(date);
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            var oDate = tempDate.ToString("dd/MM/yyyy", Culture);
            return oDate;
        }
        public static string ConvertDateToString(DateTime? date)
        {
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            var oDate = date.HasValue ? (date.Value.ToString("dd/MM/yyyy", Culture)) : "";
            return oDate;
        }
        public static TimeSpan ConvertStringTime(string date)
        {
            string iString = date;
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            TimeSpan oDate = TimeSpan.ParseExact(iString, "hh:mm:ss", Culture);
            return oDate;
        }
        public static string ConvertGetTime(DateTime date)
        {
            CultureInfo Culture = CultureInfo.GetCultureInfo("en-US");
            string oDate = date.ToString("hh:mm:ss", Culture);
            return oDate;
        }
        public static List<string> SplitText(string data)
        {
            List<string> listData = new List<string>(data.Split(','));
            return listData;
        }
        public static string JoinText(List<string> data)
        {
            string JoinData = string.Join(",", data.ToArray());
            return JoinData;
        }
        public static string JoinTextSearch(List<string> data)
        {
            string JoinData = string.Join(" , ", data.ToArray());
            return JoinData;
        }
        public static int GetMonthsDifference(DateTime startTime, DateTime endTime)
        {
            if (startTime > endTime) return GetMonthsDifference(endTime, startTime);

            var monthDiff = Math.Abs((endTime.Year * 12 + (endTime.Month - 1)) - (startTime.Year * 12 + (startTime.Month - 1)));

            if (startTime.AddMonths(monthDiff) > endTime || endTime.Day < startTime.Day)
            {
                return monthDiff - 1;
            }
            else
            {
                return monthDiff;
            }
        }
        public static int GetDayDifference(DateTime startTime, DateTime endTime)
        {
            TimeSpan span = endTime.Subtract(startTime);
            var dayDiff = span.Days;

            return dayDiff;
        }

        public static string GetMethodName([CallerMemberName] string caller = null)
        {
            return caller;
        }

        public static string InjectionClear(string sql)
        {
            sql = sql.Replace("1=1", "");
            sql = sql.Replace("1 =1", "");
            sql = sql.Replace("1= 1", "");
            sql = sql.Replace("1 = 1", "");
            sql = sql.Replace("DROP TABLE", "");
            sql = sql.Replace("TRUNCATE TABLE", "");
            return sql;
        }

        public static string GetToken(HttpContext context)
        {
            if (context != null && !string.IsNullOrEmpty(context.Request.Headers.Authorization))
            {
                return context.Request.Headers.Authorization.ToString().Replace("Bearer ", "");
            }
            else
            {
                return string.Empty;
            }
        }

        public static int GetUnixTimestamp(DateTime dt)
        {
            //var timeSpan = (dt - new DateTime(1970, 1, 1, 0, 0, 0));
            //return (int)timeSpan.TotalSeconds;

            var timeAsia = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(dt, "SE Asia Standard Time");
            var unixTime = ((DateTimeOffset)timeAsia).ToUnixTimeSeconds();

            return (int)unixTime;
        }

        public static DateTime UnixTimeStampToDateTime(int unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            //System.DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, 0);
            //dt = dt.AddSeconds(unixTimeStamp);
            //return dt;

            return DateTimeOffset.FromUnixTimeSeconds(unixTimeStamp).DateTime;
        }

        public static string GetClientIP(HttpRequest req)
        {
            string clientIP = "";

            try
            {
                string ipAddress = string.Empty;
                IPAddress ip = req.HttpContext.Connection.RemoteIpAddress;

                if (ip != null)
                {
                    if (ip.AddressFamily == System.Net.Sockets.AddressFamily.InterNetworkV6)
                    {
                        ip = Dns.GetHostEntry(ip).AddressList
                            .First(x => x.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork);
                    }

                    ipAddress = ip.ToString();
                    clientIP = ip.ToString();
                }

                StringValues values;

                req.Headers.TryGetValue("X-Forwarded-For", out values);
                if (!StringValues.IsNullOrEmpty(values))
                {
                    var rawValues = values.ToString();

                    if (!String.IsNullOrEmpty(rawValues))
                    {
                        var ipList = rawValues.Split(",");

                        var temp = ipList[0];
                        var tempList = temp.Split(":");

                        clientIP = tempList[0];
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return clientIP;
        }
      
        public static bool IntBetween(int input, int start, int end)
        {
            if (start <= input && input <= end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool DoubleBetween(double? input, double? start, double? end)
        {
            if (input.HasValue && start.HasValue && end.HasValue && start <= input && input <= end)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static string ThaiBahtText(string strNumber, bool IsTrillion = false)
        {
            string BahtText = "";
            string strTrillion = "";
            string[] strThaiNumber = { "ศูนย์", "หนึ่ง", "สอง", "สาม", "สี่", "ห้า", "หก", "เจ็ด", "แปด", "เก้า", "สิบ" };
            string[] strThaiPos = { "", "สิบ", "ร้อย", "พัน", "หมื่น", "แสน", "ล้าน" };

            decimal decNumber = 0;
            decimal.TryParse(strNumber, out decNumber);

            if (decNumber == 0)
            {
                return "ศูนย์บาทถ้วน";
            }

            strNumber = decNumber.ToString("0.00");
            string strInteger = strNumber.Split('.')[0];
            string strSatang = strNumber.Split('.')[1];

            if (strInteger.Length > 13)
                throw new Exception("รองรับตัวเลขได้เพียง ล้านล้าน เท่านั้น!");

            bool _IsTrillion = strInteger.Length > 7;
            if (_IsTrillion)
            {
                strTrillion = strInteger.Substring(0, strInteger.Length - 6);
                BahtText = ThaiBahtText(strTrillion, _IsTrillion);
                strInteger = strInteger.Substring(strTrillion.Length);
            }

            int strLength = strInteger.Length;
            for (int i = 0; i < strInteger.Length; i++)
            {
                string number = strInteger.Substring(i, 1);
                if (number != "0")
                {
                    if (i == strLength - 1 && number == "1" && strLength != 1)
                    {
                        BahtText += "เอ็ด";
                    }
                    else if (i == strLength - 2 && number == "2" && strLength != 1)
                    {
                        BahtText += "ยี่";
                    }
                    else if (i != strLength - 2 || number != "1")
                    {
                        BahtText += strThaiNumber[int.Parse(number)];
                    }

                    BahtText += strThaiPos[(strLength - i) - 1];
                }
            }

            if (IsTrillion)
            {
                return BahtText + "ล้าน";
            }

            if (strInteger != "0")
            {
                BahtText += "บาท";
            }

            if (strSatang == "00")
            {
                BahtText += "ถ้วน";
            }
            else
            {
                strLength = strSatang.Length;
                for (int i = 0; i < strSatang.Length; i++)
                {
                    string number = strSatang.Substring(i, 1);
                    if (number != "0")
                    {
                        if (i == strLength - 1 && number == "1" && strSatang[0].ToString() != "0")
                        {
                            BahtText += "เอ็ด";
                        }
                        else if (i == strLength - 2 && number == "2" && strSatang[0].ToString() != "0")
                        {
                            BahtText += "ยี่";
                        }
                        else if (i != strLength - 2 || number != "1")
                        {
                            BahtText += strThaiNumber[int.Parse(number)];
                        }

                        BahtText += strThaiPos[(strLength - i) - 1];
                    }
                }

                BahtText += "สตางค์";
            }

            return BahtText;
        }

        public static List<T> ConvertDataTableToList<T>(DataTable dt) where T : new()
        {
            List<T> list = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T obj = new T();
                foreach (DataColumn col in dt.Columns)
                {
                    string columnName = Regex.Replace(col.ColumnName, @"((^\w)|(\s|\p{P})\w)",
                                    match => match.Value.ToUpper());

                    var prop = obj.GetType().GetProperty(columnName);
                    if (prop != null && row[col] != DBNull.Value)
                        prop.SetValue(obj, row[col]);
                }
                list.Add(obj);
            }
            return list;
        }
    }
}

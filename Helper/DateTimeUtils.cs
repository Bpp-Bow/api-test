using System.Globalization;

namespace N_Health_API.Helper
{
    public class DateTimeUtils
    {
        private const string _timezoneAsia = "SE Asia Standard Time";

        public DateTimeUtils()
        {
            var cultureInfo = new CultureInfo("en-US");
            CultureInfo.DefaultThreadCurrentCulture = cultureInfo;
        }

        public DateTime NowDateTime()
        {
            return TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, _timezoneAsia);
        }

        public long NowTimeStamp()
        {
            var dt = TimeZoneInfo.ConvertTimeBySystemTimeZoneId(DateTime.Now, _timezoneAsia);
            long unixTime = ((DateTimeOffset)dt).ToUnixTimeMilliseconds();

            return unixTime;
        }
    }
}

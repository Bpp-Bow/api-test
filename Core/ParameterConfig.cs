namespace N_Health_API.Core
{
    public class ParameterConfig
    {
        public string AWS_DB_HOST { get; internal set; }
        public string AWS_DB_NAME { get; internal set; }
        public string AWS_DB_USER { get; internal set; }
        public string AWS_DB_PASS { get; internal set; }

        internal void LoadParam()
        {
            if (IsNullOrEmpty(AWS_DB_HOST))
            {
                AWS_DB_HOST = Environment.GetEnvironmentVariable("AWS_DB_HOST");
                AWS_DB_NAME = Environment.GetEnvironmentVariable("AWS_DB_NAME");
                AWS_DB_USER = Environment.GetEnvironmentVariable("AWS_DB_USER");
                AWS_DB_PASS = Environment.GetEnvironmentVariable("AWS_DB_PASS");

            }
        }

        public static bool IsNullOrEmpty(string s)
        {
            return (s == null || s == String.Empty) ? true : false;
        }

    }
}

using NpgsqlTypes;

namespace N_Health_API.Models
{
    public class DBParameter
    {
        public string? Name { get; set; }
        public NpgsqlDbType Type { get; set; }
        public object? Value { get; set; }
    }
}

using System;

namespace Organizations.Data.Entities
{
    public class AppDetails
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Code { get; set; } = string.Empty;
        public string Version { get; set; } = string.Empty;
        public DateTime DateVersion { get; set; } = DateTime.UtcNow;
    }
}
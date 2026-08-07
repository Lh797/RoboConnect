using System.Collections.Generic;

namespace RoboConnect.Models
{
    public class ProviderProfileViewModel
    {
        public string DisplayName { get; set; } = string.Empty;
        public string ProviderType { get; set; } = string.Empty;
        public string Bio { get; set; } = string.Empty;
        public List<string> ExpertiseTags { get; set; } = new();
        public decimal Rating { get; set; }
        public string ContactEmail { get; set; } = string.Empty;
        public bool IsFeatured { get; set; }
    }
}
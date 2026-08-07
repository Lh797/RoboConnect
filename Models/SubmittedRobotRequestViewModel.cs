using System;
using System.Collections.Generic;

namespace RoboConnect.Models
{
    public class SubmittedRobotRequestViewModel
    {
        public int Id { get; set; }
        public string RequestTitle { get; set; } = string.Empty;
        public string RobotType { get; set; } = string.Empty;
        public string UseCaseCategory { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string BudgetRange { get; set; } = string.Empty;
        public string PreferredTimeline { get; set; } = string.Empty;
        public string ContactPreference { get; set; } = string.Empty;
        public List<string> Features { get; set; } = new();
        public DateTime SubmittedAt { get; set; }
    }
}
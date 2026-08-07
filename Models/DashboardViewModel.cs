using System.Collections.Generic;

namespace RoboConnect.Models
{
    public class DashboardViewModel
    {
        public DashboardStatsViewModel Stats { get; set; } = new();
        public List<CategoryBreakdownItem> RequestsByRobotType { get; set; } = new();
        public List<CategoryBreakdownItem> PostsByTopic { get; set; } = new();
        public List<RecentActivityItem> RecentRequests { get; set; } = new();
        public List<RecentActivityItem> RecentPosts { get; set; } = new();
        public List<RecentActivityItem> RecentMessages { get; set; } = new();
    }

    public class DashboardStatsViewModel
    {
        public int TotalRequests { get; set; }
        public int TotalProviders { get; set; }
        public int TotalDiscussionPosts { get; set; }
        public int TotalChatMessages { get; set; }
    }

    public class CategoryBreakdownItem
    {
        public string Label { get; set; } = string.Empty;
        public int Count { get; set; }
    }

    public class RecentActivityItem
    {
        public string Title { get; set; } = string.Empty;
        public string Subtitle { get; set; } = string.Empty;
        public string Meta { get; set; } = string.Empty;
        public string TimeAgo { get; set; } = string.Empty;
        public string ActivityType { get; set; } = string.Empty;
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RoboConnect.Data;
using RoboConnect.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RoboConnect.Controllers
{
    public class DashboardController : Controller
    {
        private readonly RoboConnectDbContext _context;

        public DashboardController(RoboConnectDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var totalRequests = await _context.RobotRequests.CountAsync();
            var totalDiscussionPosts = await _context.DiscussionPosts.CountAsync();

            var requestsByRobotType = await _context.RobotRequests
                .GroupBy(r => r.RobotType)
                .Select(g => new CategoryBreakdownItem
                {
                    Label = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            var postsByTopic = await _context.DiscussionPosts
                .GroupBy(p => p.TopicTag)
                .Select(g => new CategoryBreakdownItem
                {
                    Label = g.Key,
                    Count = g.Count()
                })
                .OrderByDescending(x => x.Count)
                .ToListAsync();

            var recentRequestData = await _context.RobotRequests
                .OrderByDescending(r => r.SubmittedAt)
                .Take(3)
                .Select(r => new
                {
                    r.RequestTitle,
                    r.RobotType,
                    r.PreferredTimeline,
                    r.SubmittedAt
                })
                .ToListAsync();

            var recentRequests = recentRequestData
                .Select(r => new RecentActivityItem
                {
                    Title = r.RequestTitle,
                    Subtitle = r.RobotType,
                    Meta = r.PreferredTimeline,
                    TimeAgo = GetTimeAgo(r.SubmittedAt),
                    ActivityType = "request"
                })
                .ToList();

            var recentPostData = await _context.DiscussionPosts
                .OrderByDescending(p => p.PostedAt)
                .Take(3)
                .Select(p => new
                {
                    p.Title,
                    p.TopicTag,
                    p.AuthorName,
                    p.PostedAt
                })
                .ToListAsync();

            var recentPosts = recentPostData
                .Select(p => new RecentActivityItem
                {
                    Title = p.Title,
                    Subtitle = p.TopicTag,
                    Meta = "by " + p.AuthorName,
                    TimeAgo = GetTimeAgo(p.PostedAt),
                    ActivityType = "post"
                })
                .ToList();

            var model = new DashboardViewModel
            {
                Stats = new DashboardStatsViewModel
                {
                    TotalRequests = totalRequests,
                    TotalProviders = 6,
                    TotalDiscussionPosts = totalDiscussionPosts,
                    TotalChatMessages = 23
                },

                RequestsByRobotType = requestsByRobotType,
                PostsByTopic = postsByTopic,

                RecentRequests = recentRequests,
                RecentPosts = recentPosts,

                RecentMessages = new List<RecentActivityItem>
                {
                    new RecentActivityItem
                    {
                        Title = "Looking for partners on a data analytics dashboard",
                        Subtitle = "Solutions",
                        Meta = "by Insight Motion AI",
                        TimeAgo = "10m ago",
                        ActivityType = "message"
                    },
                    new RecentActivityItem
                    {
                        Title = "New modular mount for assistive platforms",
                        Subtitle = "Accessories",
                        Meta = "by Adaptive Tools Lab",
                        TimeAgo = "20m ago",
                        ActivityType = "message"
                    },
                    new RecentActivityItem
                    {
                        Title = "Excited to join the community",
                        Subtitle = "General",
                        Meta = "by You",
                        TimeAgo = "45m ago",
                        ActivityType = "message"
                    }
                }
            };

            return View(model);
        }

        private static string GetTimeAgo(DateTime dateTime)
        {
            var diff = DateTime.Now - dateTime;

            if (diff.TotalMinutes < 1)
                return "just now";

            if (diff.TotalMinutes < 60)
                return $"{(int)diff.TotalMinutes}m ago";

            if (diff.TotalHours < 24)
                return $"{(int)diff.TotalHours}h ago";

            return $"{(int)diff.TotalDays}d ago";
        }
    }
}
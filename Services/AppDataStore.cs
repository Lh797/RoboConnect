using RoboConnect.Models;
using System;
using System.Collections.Generic;

namespace RoboConnect.Services
{
    public static class AppDataStore
    {
        public static List<SubmittedRobotRequestViewModel> Requests { get; } = new()
        {
            new SubmittedRobotRequestViewModel
            {
                Id = 1,
                RequestTitle = "Classroom assistive robot pilot",
                RobotType = "Assistive Robot",
                UseCaseCategory = "Accessibility",
                Description = "Looking for an assistive robot for special needs classroom support.",
                BudgetRange = "HKD 50,001 - 100,000",
                PreferredTimeline = "Within 1 month",
                ContactPreference = "Email",
                Features = new List<string> { "Data Analytics", "Maintenance Support" },
                SubmittedAt = DateTime.Now.AddMinutes(-25)
            },
            new SubmittedRobotRequestViewModel
            {
                Id = 2,
                RequestTitle = "Autonomous delivery cart for campus",
                RobotType = "Delivery Robot",
                UseCaseCategory = "Logistics",
                Description = "Need a delivery robot for campus mail and parcel distribution.",
                BudgetRange = "Above HKD 100,000",
                PreferredTimeline = "Within 3 months",
                ContactPreference = "Platform Chat",
                Features = new List<string> { "Integration Support" },
                SubmittedAt = DateTime.Now.AddHours(-2)
            }
        };

        public static List<ProviderProfileViewModel> Providers { get; } = new()
        {
            new ProviderProfileViewModel
            {
                DisplayName = "Alex Robotics Studio",
                ProviderType = "SolutionProvider",
                Bio = "Designs end-to-end robotic workflows for education, service environments, and pilot deployments.",
                ExpertiseTags = new List<string> { "Workflow Design", "AI Integration", "Education" },
                Rating = 4.8m,
                ContactEmail = "alex@roboconnect-demo.com",
                IsFeatured = true
            },
            new ProviderProfileViewModel
            {
                DisplayName = "MechaCare Systems",
                ProviderType = "HardwareProvider",
                Bio = "Provides maintenance, diagnostics, calibration, and component replacement for deployed robots.",
                ExpertiseTags = new List<string> { "Maintenance", "Calibration", "Field Service" },
                Rating = 4.6m,
                ContactEmail = "support@mechacare-demo.com",
                IsFeatured = false
            }
        };

        public static List<DiscussionPostViewModel> Posts { get; } = new()
        {
            new DiscussionPostViewModel
            {
                Id = 1,
                Title = "Best practices for robot arm calibration?",
                Content = "We recently deployed a 6-axis arm in an educational lab and noticed drift after two weeks.",
                TopicTag = "Hardware",
                AuthorName = "MechaCare Team",
                LikeCount = 12,
                PostedAt = DateTime.Now.AddHours(-5)
            },
            new DiscussionPostViewModel
            {
                Id = 2,
                Title = "Sharing a Python pipeline for sensor data cleaning",
                Content = "Built a lightweight pipeline that filters noise from LiDAR scans before feeding them into the navigation stack.",
                TopicTag = "Data Science",
                AuthorName = "Insight Motion AI",
                LikeCount = 28,
                PostedAt = DateTime.Now.AddHours(-3)
            }
        };

        public static List<ChatMessageViewModel> Messages { get; } = new()
        {
            new ChatMessageViewModel
            {
                Id = 1,
                SenderName = "Alex Robotics",
                Room = "General",
                MessageText = "Welcome to the RoboConnect chat space! Pick a room and start the conversation.",
                SentAt = DateTime.Now.AddHours(-3),
                IsCurrentUser = false
            },
            new ChatMessageViewModel
            {
                Id = 2,
                SenderName = "Insight Motion AI",
                Room = "Solutions",
                MessageText = "Looking for partners on a data analytics dashboard for delivery robots.",
                SentAt = DateTime.Now.AddMinutes(-10),
                IsCurrentUser = false
            }
        };
    }
}
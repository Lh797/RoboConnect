using System;
using System.ComponentModel.DataAnnotations;

namespace RoboConnect.Models
{
    public class DiscussionPostViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Title is required.")]
        [StringLength(120, ErrorMessage = "Title cannot exceed 120 characters.")]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Content is required.")]
        [StringLength(2000, ErrorMessage = "Content cannot exceed 2000 characters.")]
        public string Content { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a topic.")]
        public string TopicTag { get; set; } = string.Empty;

        [Required(ErrorMessage = "Author name is required.")]
        [StringLength(50, ErrorMessage = "Author name cannot exceed 50 characters.")]
        public string AuthorName { get; set; } = string.Empty;

        public int LikeCount { get; set; }
        public DateTime PostedAt { get; set; }

        public string GetPostedAgo()
        {
            var diff = DateTime.Now - PostedAt;

            if (diff.TotalMinutes < 1) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes}m ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours}h ago";
            return $"{(int)diff.TotalDays}d ago";
        }
    }
}
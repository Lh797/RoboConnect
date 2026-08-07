using System;
using System.ComponentModel.DataAnnotations;

namespace RoboConnect.Models
{
    public class ChatMessageViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Your name is required.")]
        [StringLength(50, ErrorMessage = "Sender name cannot exceed 50 characters.")]
        public string SenderName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a room.")]
        public string Room { get; set; } = string.Empty;

        [Required(ErrorMessage = "Message text is required.")]
        [StringLength(500, ErrorMessage = "Message cannot exceed 500 characters.")]
        public string MessageText { get; set; } = string.Empty;

        public DateTime SentAt { get; set; }
        public bool IsCurrentUser { get; set; }

        public string GetSentAgo()
        {
            var diff = DateTime.Now - SentAt;

            if (diff.TotalMinutes < 1) return "just now";
            if (diff.TotalMinutes < 60) return $"{(int)diff.TotalMinutes}m ago";
            if (diff.TotalHours < 24) return $"{(int)diff.TotalHours}h ago";
            return $"{(int)diff.TotalDays}d ago";
        }
    }
}
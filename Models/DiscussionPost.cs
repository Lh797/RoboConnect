using System;
using System.ComponentModel.DataAnnotations;

namespace RoboConnect.Models
{
    public class DiscussionPost
    {
        public int Id { get; set; }

        [Required]
        [StringLength(120)]
        public string Title { get; set; } = string.Empty;

        [Required]
        [StringLength(2000)]
        public string Content { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string AuthorName { get; set; } = string.Empty;

        [Required]
        [StringLength(50)]
        public string TopicTag { get; set; } = string.Empty;

        public int LikeCount { get; set; }

        public DateTime PostedAt { get; set; }
    }
}
using System;
using System.ComponentModel.DataAnnotations;

namespace RoboConnect.Models
{
    public class RobotRequest
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string RequestTitle { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string RobotType { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string UseCaseCategory { get; set; } = string.Empty;

        [Required]
        [StringLength(1000)]
        public string Description { get; set; } = string.Empty;

        [StringLength(300)]
        public string FeaturesSummary { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string BudgetRange { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string PreferredTimeline { get; set; } = string.Empty;

        [Required]
        [StringLength(80)]
        public string ContactPreference { get; set; } = string.Empty;

        public DateTime SubmittedAt { get; set; }
    }
}
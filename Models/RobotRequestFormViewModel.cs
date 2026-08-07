using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RoboConnect.Models
{
    public class RobotRequestFormViewModel
    {
        [Required(ErrorMessage = "Request title is required.")]
        [StringLength(100, ErrorMessage = "Request title cannot exceed 100 characters.")]
        [Display(Name = "Request Title")]
        public string RequestTitle { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a robot type.")]
        [Display(Name = "Robot Type")]
        public string RobotType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Use case category is required.")]
        [StringLength(80, ErrorMessage = "Use case category cannot exceed 80 characters.")]
        [Display(Name = "Use Case Category")]
        public string UseCaseCategory { get; set; } = string.Empty;

        [Required(ErrorMessage = "Description is required.")]
        [StringLength(1000, ErrorMessage = "Description cannot exceed 1000 characters.")]
        [Display(Name = "Description")]
        public string Description { get; set; } = string.Empty;

        [Display(Name = "Data Analytics")]
        public bool NeedDataAnalytics { get; set; }

        [Display(Name = "Custom Accessory")]
        public bool NeedCustomAccessory { get; set; }

        [Display(Name = "Maintenance Support")]
        public bool NeedMaintenanceSupport { get; set; }

        [Display(Name = "Integration Support")]
        public bool NeedIntegrationSupport { get; set; }

        [Required(ErrorMessage = "Please choose a budget range.")]
        [Display(Name = "Budget Range")]
        public string BudgetRange { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please choose a preferred timeline.")]
        [Display(Name = "Preferred Timeline")]
        public string PreferredTimeline { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please choose a contact preference.")]
        [Display(Name = "Contact Preference")]
        public string ContactPreference { get; set; } = string.Empty;

        public List<string> GetSelectedFeatures()
        {
            var features = new List<string>();

            if (NeedDataAnalytics) features.Add("Data Analytics");
            if (NeedCustomAccessory) features.Add("Custom Accessory");
            if (NeedMaintenanceSupport) features.Add("Maintenance Support");
            if (NeedIntegrationSupport) features.Add("Integration Support");

            return features;
        }
    }
}
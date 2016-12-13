using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models
{
    public class HealthInsurance
    {
        [Key]
        public int HealthInsPlanId { get; set; }
        [Required]
        public string HealthInsPlanName { get; set; }
        [Required]
        public string HealthInsPlanSummary { get; set; }
        [Required]
        public string HealthInsDeductible { get; set; }
        [Required]
        public string HealthInsPremium { get; set; }
        [Required]
        public string HealthInsPlanLink { get; set; }
    }
}

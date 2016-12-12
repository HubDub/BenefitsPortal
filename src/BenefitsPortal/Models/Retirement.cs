using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models
{
    public class Retirement
    {
        [Key]
        public int RetirementPlanId { get; set; }
        [Required]
        public string RetirementPlanName { get; set; }
        [Required]
        public string RetirementPlanSummary { get; set; }
        [Required]
        public string RetirementPlanLink { get; set; }
    }
}

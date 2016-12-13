using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models
{
    public class LifeInsurance
    {
        [Key]
        public int LifeInsPlanId { get; set; }
        [Required]
        public string LifeInsPlanName { get; set; }
        [Required]
        public string LifeInsPlanSummary { get; set; }
        [Required]
        public string LifeInsPlanLink { get; set; }
    }
}

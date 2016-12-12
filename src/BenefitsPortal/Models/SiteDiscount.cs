using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models
{
    public class SiteDiscount
    {
        [Key]
        public int SiteDiscountId { get; set; }
        [Required]
        public string SiteName { get; set; }
        [Required]
        public string DiscountType { get; set; }
        [Required]
        public string Instructions { get; set; }
        [Required]
        public string Link { get; set; }
    }
}

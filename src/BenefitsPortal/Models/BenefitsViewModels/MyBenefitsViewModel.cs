using BenefitsPortal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models.BenefitsViewModels
{
    public class MyBenefitsViewModel
    {
        public IEnumerable<SiteDiscount> SiteDiscounts { get; set; }
        public MyBenefitsViewModel() { }
        public Employee Employee { get; set; }
        public LifeInsurance LifeInsurance { get; set; }
        public Retirement Retirement { get; set; }
        public HealthInsurance HealthInsurance { get; set; }
    }
}

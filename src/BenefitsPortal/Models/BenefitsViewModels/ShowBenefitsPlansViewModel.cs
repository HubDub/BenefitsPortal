using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models.BenefitsViewModels
{
    public class ShowBenefitsPlansViewModel
    {
        public ShowBenefitsPlansViewModel() { }
        public IEnumerable<LifeInsurance> LifeInsurances { get; set; }
        public IEnumerable<HealthInsurance> HealthInsurances { get; set; }
        public IEnumerable<Retirement> RetirementPlans { get; set; }
    }
}

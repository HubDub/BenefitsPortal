using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models
{
    public class DashboardBenefit
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmployeeId { get; set; }
        public string Department { get; set; }
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        public double PtoRate { get; set; }
        public double PtoTotal { get; set; }
        public string HealthPlan { get; set; }
        public int RetirementPlanPercentage { get; set; }
    }
}

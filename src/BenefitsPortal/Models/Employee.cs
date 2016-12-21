using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models
{
    public class Employee
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
        [DataType(DataType.Date)]
        public DateTime? TerminationDate { get; set; }
        [Required]
        public double BiWeeklySalary { get; set; }
        public double? AnnualSalary { get; set; }
        [Required]
        public string StreetAddress { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]
        public string Zip { get; set; } 
        [Required]
        public string EmployeeId { get; set; }
        [Required]
        public string Department { get; set; }
        [DataType(DataType.Date)]
        public DateTime? LastAccrualDate { get; set; }
        [Required]
        public double PtoRate { get; set; }
        [Required]
        public double PtoTotal { get; set; }
        [Required]
        public int HealthInsurancePlanId { get; set; }
        [Required]
        public int LifeInsurancePlanId { get; set; }
        [Required]
        public int RetirementPlanId { get; set; }
        [Required]
        public int RetirementPlanPercentage { get; set; }
    }
}

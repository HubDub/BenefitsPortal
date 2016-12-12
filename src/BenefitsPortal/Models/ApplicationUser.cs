using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace BenefitsPortal.Models
{
    // Add profile data for application users by adding properties to the ApplicationUser class
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public DateTime HireDate { get; set; }
        public DateTime? TerminationDate { get; set; }
        [Required]
        public double BiWeeklySalary { get; set; }
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

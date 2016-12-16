using BenefitsPortal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models.BenefitsViewModels
{
    public class DashboardViewModel
    {
        public IEnumerable<Employee> Employees { get; set; }
        public DashboardViewModel(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx1) { } 
        //public IEnumerable<DashboardBenefit> DashboardBenefits { get; set; }
    }
}

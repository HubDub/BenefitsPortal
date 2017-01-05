using BenefitsPortal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models.BenefitsViewModels
{
    public class AccrualViewModel
    {
        //public AccrualViewModel(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx1) { }
        public AccrualViewModel() { }
        public IEnumerable<Employee> Employees { get; set; }
        public Employee Employee { get; set; }
        
    }
}

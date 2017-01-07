using BenefitsPortal.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Models.BenefitsViewModels
{
    public class AddEmployeeViewModel
    {
        public AddEmployeeViewModel() { }
        public Employee Employee { get; set; }
    }
}

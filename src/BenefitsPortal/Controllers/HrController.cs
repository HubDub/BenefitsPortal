using BenefitsPortal.Data;
using BenefitsPortal.Models;
using BenefitsPortal.Models.BenefitsViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Controllers
{
    [Authorize]
    public class HrController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private ApplicationDbContext newContext;
        public HrController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx1)
        {
            _userManager = userManager;
            newContext = ctx1;
        }

        //this method will get the employees from the DB and pass them to the view model
        public async Task<IActionResult> Dashboard()
        {
            AllEmployeesViewModel model = new AllEmployeesViewModel(_userManager, newContext);
            model.Employees = await newContext.Employee.ToListAsync();
            return View(model);
        }
    }
}

﻿using BenefitsPortal.Data;
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

        //this method gets the current user
        [Authorize]
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        //this method will get the employees from the DB and pass them to the view model
        public async Task<IActionResult> Dashboard()
        {
            DashboardViewModel model = new DashboardViewModel(_userManager, newContext);
            model.Employees = await newContext.Employee.ToListAsync();
            //still working on making this work
            //var EmployeeBenefits =
            //    (from e in newContext.Employee
            //    join h in newContext.HealthInsurance on e.HealthInsurancePlanId equals h.HealthInsPlanId
            //    select new { FirstName = e.FirstName, LastName = e.LastName, EmployeeId = e.EmployeeId, Department = e.Department, HireDate = e.HireDate, HealthPlan = h.HealthInsPlanName, PTORate = e.PtoRate, RetirementPlanPercentage = e.RetirementPlanPercentage, PTOTotal = e.PtoTotal }).ToListAsync();

        //model.HealthInsurance = await newContext.HealthInsurance.ToListAsync();
        //model.DashboardBenefits = EmployeeBenefits;
            return View(model);
        }

        //this method will get one employee, who is the user, from the DB, to list their details. It will also pull their life insurance, health insurance, retirement vendor, and site-wide benefits from those tables.
        public async Task<IActionResult> MyBenefits()
        {
            MyBenefitsViewModel model = new MyBenefitsViewModel(_userManager, newContext);
            var user = await GetCurrentUserAsync();
            model.SiteDiscounts = await newContext.SiteDiscount.ToListAsync();
            model.Employee = newContext.Employee.Where(e => e.EmployeeId == user.EmployeeId).SingleOrDefault();
            model.HealthInsurance = newContext.HealthInsurance.Where(h => h.HealthInsPlanId == model.Employee.HealthInsurancePlanId).SingleOrDefault();
            model.LifeInsurance = newContext.LifeInsurance.Where(l => l.LifeInsPlanId == model.Employee.LifeInsurancePlanId).SingleOrDefault();
            model.Retirement = newContext.Retirement.Where(r => r.RetirementPlanId == model.Employee.RetirementPlanId).SingleOrDefault();
            return View(model);
        }
    }
}

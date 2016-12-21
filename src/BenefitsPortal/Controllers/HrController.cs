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

            var EmployeeBenefits = await
                (from e in newContext.Employee
                 join h in newContext.HealthInsurance on e.HealthInsurancePlanId equals h.HealthInsPlanId
                 select new DashboardBenefit { FirstName = e.FirstName, LastName = e.LastName, EmployeeId = e.EmployeeId, Department = e.Department, HireDate = e.HireDate, HealthPlan = h.HealthInsPlanName, PtoRate = e.PtoRate, RetirementPlanPercentage = e.RetirementPlanPercentage, PtoTotal = e.PtoTotal }).ToListAsync();

            model.DashboardBenefits = EmployeeBenefits;
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

        //this method will list all of the employees and present the PTO accrual view
        public async Task<IActionResult> Accruals()
        {
            AccrualViewModel model = new AccrualViewModel(_userManager, newContext);
            model.Employees = await newContext.Employee.ToListAsync();
            return View(model);
        }

        //this method returns the form to add a new employee to the database
        public IActionResult AddEmployee()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel(_userManager, newContext);
            return View(model);
        }

        //this overloaded method grabs the form data from AddEmployee, checks it against the model and then sends it to the DB
        [HttpPost]
        public async Task<IActionResult> AddEmployee(Employee Employee)
        {
            if (ModelState.IsValid)
            {
                newContext.Employee.Add(Employee);
                await newContext.SaveChangesAsync();
                return RedirectToAction("Dashboard");
            }
            //if model state is not valid return error
            return BadRequest();
        }
    }
}

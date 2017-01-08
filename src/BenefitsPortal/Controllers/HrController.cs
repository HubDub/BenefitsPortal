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

        //this constructor sets up a new instance of the controller and passes the user manager and DBContext in so these
        //private variables can be altered.
        public HrController(UserManager<ApplicationUser> userManager, ApplicationDbContext ctx1)
        {
            _userManager = userManager;
            newContext = ctx1;
        }

        //this method gets the current user and makes it available
        [Authorize]
        private Task<ApplicationUser> GetCurrentUserAsync()
        {
            return _userManager.GetUserAsync(HttpContext.User);
        }

        //this method will get the employees from the DB and pass them to the view model. it instantiates a new
        //view model, then uses Linq to pull the employees from the database along with the appropriate benefit
        //tables. Then it assigns those to the model and passes that model to the view.
        public async Task<IActionResult> Dashboard()
        {
            DashboardViewModel model = new DashboardViewModel();

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
            MyBenefitsViewModel model = new MyBenefitsViewModel();
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
            AccrualViewModel model = new AccrualViewModel();
            model.Employees = await newContext.Employee.ToListAsync();
            return View(model);
        }

        //this method will receive an array of employee objects from the jquery json post and then update the PTO total in the database for each employee in the list. 
        [HttpPost]
        public async Task<IActionResult> AccruePTO([FromBody] List<Employee> EmployeesList)
        {

            foreach(Employee emp in EmployeesList)
            {
                Employee e = newContext.Employee.Where(em => em.EmployeeId == emp.EmployeeId).SingleOrDefault();
                e.PtoTotal = emp.PtoTotal;
                e.PtoUsedLast = emp.PtoUsedLast;
                newContext.Employee.Update(e);
            }
            
            await newContext.SaveChangesAsync();
            return RedirectToAction("Dashboard", "Hr");
            
        }

        //this method returns the form to add a new employee to the database
        public IActionResult AddEmployee()
        {
            AddEmployeeViewModel model = new AddEmployeeViewModel();
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

        //this method will show the view of a single employee so the employee can be edited. It passes the employeeId as the argument and uses that to get the employee from the DB. then gives that back to the view. 
        //public async Task<IActionResult> Edit(int? employeeId)
        //{
        //    if (employeeId == null)
        //    {
        //        return NotFound();
        //    }

        //    var employee = await newContext.Employee.SingleOrDefaultAsync(e => e.EmployeeId == employeeId);
        //}
    }
}

using BenefitsPortal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace BenefitsTests
{
    public class Tests
    {
        HealthInsurance healthPlan = new HealthInsurance
        {
            HealthInsPlanName = "Humana Class B",
            HealthInsPremium = "50",
            HealthInsDeductible = "500",
            HealthInsPlanSummary = "average family plan",
            HealthInsPlanLink = "www.humana.com"
        };

        LifeInsurance lifePlan = new LifeInsurance
        {
            LifeInsPlanName = "Life Insurance",
            LifeInsPlanSummary = "This pays off when you die unexpectedly",
            LifeInsPlanLink = "www.lifeinsurance.com"
        };

        Retirement retirePlan = new Retirement
        {
            RetirementPlanName = "Retirement Village Plan",
            RetirementPlanSummary = "this savings plan is so that one day you can retire",
            RetirementPlanLink = "www.retire.com"
        };

        Employee employee = new Employee
        {
            FirstName = "Blake",
            LastName = "Anderson",
            HireDate = DateTime.ParseExact("07/05/2005 00:00:00", "MM/dd/yyyy HH:mm:ss", null),
            BiWeeklySalary = 3080.00,
            StreetAddress = "123 Broadway",
            City = "Nashville",
            State = "TN",
            Zip = "37075",
            EmployeeId = "2001",
            Department = "Admin",
            PtoRate = 1.15,
            PtoTotal = 75.75,
            HealthInsurancePlanId = 1,
            LifeInsurancePlanId = 1,
            RetirementPlanId = 1,
            RetirementPlanPercentage = 15
        };

        [Fact]
        public void TestTesting()
        {
            bool isMonday = true;
            Assert.True(isMonday);
        }

        [Fact]
        public void CanCreateHealthInsPlan()
        {
            Assert.NotNull(healthPlan);
        }

        [Fact]
        public void HealthPlanHasPlanName()
        {
            Assert.NotNull(healthPlan.HealthInsPlanName);
        }

        [Fact]
        public void CanCreateLifeInsPlan()
        {
            Assert.NotNull(lifePlan);
        }

        [Fact]
        public void LifeInsPlanHasPlanName()
        {
            Assert.NotNull(lifePlan.LifeInsPlanName);
        }
        [Fact]
        public void CanCreateRetirementPlan()
        {
            Assert.NotNull(retirePlan);
        }

        [Fact]
        public void RetirementPlanHasPlanName()
        {
            Assert.NotNull(retirePlan.RetirementPlanName);
        }

        [Fact]
        public void CanCreatEmployee()
        {
            Assert.NotNull(employee);
        }

        [Fact]
        public void EmployeeHasFirstName()
        {
            Assert.Equal(employee.FirstName, "Blake");
        }

        //[Fact]
        //public void TestCanPullAllEmployeesFromDB()
        //{
        //    model.Employee = await newContext.Employee.ToListAsync();
        //}

    }
}

using BenefitsPortal.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BenefitsPortal.Data
{
    public class DbInitializer
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.SiteDiscount.Any())
                {
                    return; //bc then the database has been seeded. otherwise, it seeds it
                }

                //this will seed the site discounts
                var siteDiscounts = new SiteDiscount[]
                {
                    new SiteDiscount
                    {
                        SiteName = "The Parthenon",
                        DiscountType = "Free tickets",
                        Instructions = "Show nametag or paystub",
                        Summary = "Employee and family have free admission",
                        Link = "http://www.nashville.gov/Parks-and-Recreation/Parthenon.aspx"
                    },
                    new SiteDiscount
                    {
                        SiteName = "The Hermitage",
                        DiscountType = "Free ticket",
                        Instructions = "Show nametag or paystub",
                        Summary = "Employee has free adult admission",
                        Link = "http://www.thehermitage.com"
                    },
                    new SiteDiscount
                    {
                        SiteName = "DollyWood",
                        DiscountType = "Free ticket",
                        Instructions = "Show nametag or paystub",
                        Summary = "Employee has free adult admission",
                        Link = "http://www.dollywood.com"
                    },
                    new SiteDiscount
                    {
                        SiteName = "Enterprise Rental Car",
                        DiscountType = "Discount",
                        Instructions = "Use Discount code BNFT online when reserving",
                        Summary = "20% off entire car rental",
                        Link = "http://www.enterprise.com"
                    },
                    new SiteDiscount
                    {
                        SiteName = "Opryland Hotel",
                        DiscountType = "Discount",
                        Instructions = "Use discount code BNFT online when reserving",
                        Summary = "15% off stay",
                        Link = "http://www.marriott.com/hotels/travel/bnago-gaylord-opryland-resort-and-convention-center/"
                    }
                };
                foreach (SiteDiscount s in siteDiscounts)
                {
                    context.SiteDiscount.Add(s);
                }
                context.SaveChanges();

                //the data below seeds retirement plans in the DB
                var retirementPlans = new Retirement[]
                {
                    new Retirement
                    {
                        RetirementPlanName = "Vanguard 401(k)",
                        RetirementPlanSummary = "These funds are managed through Vanguard.",
                        RetirementPlanLink = "http://www.vanguard.com"
                    }
                };
                foreach (Retirement r in retirementPlans)
                {
                    context.Retirement.Add(r);
                }
                context.SaveChanges();

                //the data below seeds life insurance plans in the DB
                var lifeInsPlans = new LifeInsurance[]
                {
                    new LifeInsurance
                    {
                        LifeInsPlanName = "Liberty Mutual Life Insurance",
                        LifeInsPlanSummary = "This plan is managed through Liberty Mutual",
                        LifeInsPlanLink = "http://www.libertymutual.com"
                    }
                };
                foreach (LifeInsurance l in lifeInsPlans)
                {
                    context.LifeInsurance.Add(l);
                }
                context.SaveChanges();

                //the data below seeds health insurance plans into the DB
                var healthInsPlans = new HealthInsurance[]
                {
                    new HealthInsurance
                    {
                        HealthInsPlanName = "Blue Cross Blue Shield 500 A",
                        HealthInsPlanSummary = "BCBS Plan 500 for individuals",
                        HealthInsPremium = "80",
                        HealthInsDeductible = "300",
                        HealthInsPlanLink = "http://www.bcbst.com"
                    },
                    new HealthInsurance
                    {
                        HealthInsPlanName = "Blue Cross Blue Shield 500 B",
                        HealthInsPlanSummary = "BCBS Plan 500 for families",
                        HealthInsPremium = "160",
                        HealthInsDeductible = "600",
                        HealthInsPlanLink = "http://www.bcbst.com"
                    },
                    new HealthInsurance
                    {
                        HealthInsPlanName = "Blue Cross Blue Shield 200 A",
                        HealthInsPlanSummary = "BCBS Plan 200 for individuals",
                        HealthInsPremium = "40",
                        HealthInsDeductible = "1000",
                        HealthInsPlanLink = "http://www.bcbst.com"
                    },
                    new HealthInsurance
                    {
                        HealthInsPlanName = "Blue Cross Blue Shield 200 B",
                        HealthInsPlanSummary = "BCBS Plan 200 for families",
                        HealthInsPremium = "80",
                        HealthInsDeductible = "2000",
                        HealthInsPlanLink = "http://www.bcbst.com"
                    }
                };
                foreach (HealthInsurance h in healthInsPlans)
                {
                    context.HealthInsurance.Add(h);
                }
                context.SaveChanges();


                //the data below seeds employees in the DB
                var employees = new Employee[]
                {
                    new Employee
                    {
                        FirstName = "John",
                        LastName = "Doe",
                        HireDate = DateTime.ParseExact("12/15/2010 00:00:00", "MM/dd/yyyy HH:mm:ss",null),
                        BiWeeklySalary = 2308.00,
                        StreetAddress = "123 Main",
                        City = "Nashville",
                        State = "TN",
                        Zip = "37075",
                        EmployeeId = "1001",
                        Department = "HR",
                        PtoRate = 0.96,
                        PtoTotal = 100,
                        HealthInsurancePlanId = 2,
                        LifeInsurancePlanId = 1,
                        RetirementPlanId = 1,
                        RetirementPlanPercentage = 10
                    },
                    new Employee
                    {
                        FirstName = "Jane",
                        LastName = "Smith",
                        HireDate = DateTime.ParseExact("05/12/2011 00:00:00", "MM/dd/yyyy HH:mm:ss",null),
                        BiWeeklySalary = 2308.00,
                        StreetAddress = "455 Main",
                        City = "Nashville",
                        State = "TN",
                        Zip = "37075",
                        EmployeeId = "3601",
                        Department = "Sales",
                        PtoRate = 0.96,
                        PtoTotal = 12.50,
                        HealthInsurancePlanId = 3,
                        LifeInsurancePlanId = 1,
                        RetirementPlanId = 1,
                        RetirementPlanPercentage = 5
                    },
                    new Employee
                    {
                        FirstName = "Belinda",
                        LastName = "Carlisle",
                        HireDate = DateTime.ParseExact("03/01/2016 00:00:00", "MM/dd/yyyy HH:mm:ss",null),
                        BiWeeklySalary = 1538.00,
                        StreetAddress = "123 Center",
                        City = "Nashville",
                        State = "TN",
                        Zip = "37075",
                        EmployeeId = "2002",
                        Department = "Admin",
                        PtoRate = 0.77,
                        PtoTotal = 5.25,
                        HealthInsurancePlanId = 4,
                        LifeInsurancePlanId = 1,
                        RetirementPlanId = 1,
                        RetirementPlanPercentage = 4
                    },
                    new Employee
                    {
                        FirstName = "Tim",
                        LastName = "Vanilla",
                        HireDate = DateTime.ParseExact("07/05/2005 00:00:00", "MM/dd/yyyy HH:mm:ss",null),
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
                    },
                };
                foreach (Employee e in employees)
                {
                    context.Employee.Add(e);
                }
                context.SaveChanges();
            }
        }
    }
}

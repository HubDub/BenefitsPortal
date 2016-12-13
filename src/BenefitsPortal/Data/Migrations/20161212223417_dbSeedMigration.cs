using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace BenefitsPortal.Data.Migrations
{
    public partial class dbSeedMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    EmployeeId = table.Column<string>(nullable: false),
                    AnnualSalary = table.Column<double>(nullable: true),
                    BiWeeklySalary = table.Column<double>(nullable: false),
                    City = table.Column<string>(nullable: false),
                    Department = table.Column<string>(nullable: false),
                    FirstName = table.Column<string>(nullable: false),
                    HealthInsurancePlanId = table.Column<int>(nullable: false),
                    HireDate = table.Column<DateTime>(nullable: false),
                    LastAccrualDate = table.Column<DateTime>(nullable: true),
                    LastName = table.Column<string>(nullable: false),
                    LifeInsurancePlanId = table.Column<int>(nullable: false),
                    PtoRate = table.Column<double>(nullable: false),
                    PtoTotal = table.Column<double>(nullable: false),
                    RetirementPlanId = table.Column<int>(nullable: false),
                    RetirementPlanPercentage = table.Column<int>(nullable: false),
                    State = table.Column<string>(nullable: false),
                    StreetAddress = table.Column<string>(nullable: false),
                    TerminationDate = table.Column<DateTime>(nullable: true),
                    Zip = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.EmployeeId);
                });

            migrationBuilder.CreateTable(
                name: "HealthInsurance",
                columns: table => new
                {
                    HealthInsPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    HealthInsDeductible = table.Column<string>(nullable: false),
                    HealthInsPlanLink = table.Column<string>(nullable: false),
                    HealthInsPlanName = table.Column<string>(nullable: false),
                    HealthInsPlanSummary = table.Column<string>(nullable: false),
                    HealthInsPremium = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HealthInsurance", x => x.HealthInsPlanId);
                });

            migrationBuilder.CreateTable(
                name: "LifeInsurance",
                columns: table => new
                {
                    LifeInsPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LifeInsPlanLink = table.Column<string>(nullable: false),
                    LifeInsPlanName = table.Column<string>(nullable: false),
                    LifeInsPlanSummary = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LifeInsurance", x => x.LifeInsPlanId);
                });

            migrationBuilder.CreateTable(
                name: "Retirement",
                columns: table => new
                {
                    RetirementPlanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    RetirementPlanLink = table.Column<string>(nullable: false),
                    RetirementPlanName = table.Column<string>(nullable: false),
                    RetirementPlanSummary = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Retirement", x => x.RetirementPlanId);
                });

            migrationBuilder.CreateTable(
                name: "SiteDiscount",
                columns: table => new
                {
                    SiteDiscountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    DiscountType = table.Column<string>(nullable: false),
                    Instructions = table.Column<string>(nullable: false),
                    Link = table.Column<string>(nullable: false),
                    SiteName = table.Column<string>(nullable: false),
                    Summary = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteDiscount", x => x.SiteDiscountId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "HealthInsurance");

            migrationBuilder.DropTable(
                name: "LifeInsurance");

            migrationBuilder.DropTable(
                name: "Retirement");

            migrationBuilder.DropTable(
                name: "SiteDiscount");
        }
    }
}

using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using BenefitsPortal.Data;

namespace BenefitsPortal.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20170104232535_AddPtoUsed")]
    partial class AddPtoUsed
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
            modelBuilder
                .HasAnnotation("ProductVersion", "1.0.1")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("BenefitsPortal.Models.ApplicationUser", b =>
                {
                    b.Property<string>("Id");

                    b.Property<int>("AccessFailedCount");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Email")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<bool>("EmailConfirmed");

                    b.Property<string>("EmployeeId")
                        .IsRequired();

                    b.Property<bool>("LockoutEnabled");

                    b.Property<DateTimeOffset?>("LockoutEnd");

                    b.Property<string>("NormalizedEmail")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedUserName")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("PasswordHash");

                    b.Property<string>("PhoneNumber");

                    b.Property<bool>("PhoneNumberConfirmed");

                    b.Property<string>("SecurityStamp");

                    b.Property<bool>("TwoFactorEnabled");

                    b.Property<string>("UserName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedEmail")
                        .HasName("EmailIndex");

                    b.HasIndex("NormalizedUserName")
                        .IsUnique()
                        .HasName("UserNameIndex");

                    b.ToTable("AspNetUsers");
                });

            modelBuilder.Entity("BenefitsPortal.Models.Employee", b =>
                {
                    b.Property<string>("EmployeeId");

                    b.Property<double?>("AnnualSalary");

                    b.Property<double>("BiWeeklySalary");

                    b.Property<string>("City")
                        .IsRequired();

                    b.Property<string>("Department")
                        .IsRequired();

                    b.Property<string>("FirstName")
                        .IsRequired();

                    b.Property<int>("HealthInsurancePlanId");

                    b.Property<DateTime>("HireDate");

                    b.Property<DateTime?>("LastAccrualDate");

                    b.Property<string>("LastName")
                        .IsRequired();

                    b.Property<int>("LifeInsurancePlanId");

                    b.Property<double>("PtoRate");

                    b.Property<double>("PtoTotal");

                    b.Property<double>("PtoUsedLast");

                    b.Property<int>("RetirementPlanId");

                    b.Property<int>("RetirementPlanPercentage");

                    b.Property<string>("State")
                        .IsRequired();

                    b.Property<string>("StreetAddress")
                        .IsRequired();

                    b.Property<DateTime?>("TerminationDate");

                    b.Property<string>("Zip")
                        .IsRequired();

                    b.HasKey("EmployeeId");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("BenefitsPortal.Models.HealthInsurance", b =>
                {
                    b.Property<int>("HealthInsPlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("HealthInsDeductible")
                        .IsRequired();

                    b.Property<string>("HealthInsPlanLink")
                        .IsRequired();

                    b.Property<string>("HealthInsPlanName")
                        .IsRequired();

                    b.Property<string>("HealthInsPlanSummary")
                        .IsRequired();

                    b.Property<string>("HealthInsPremium")
                        .IsRequired();

                    b.HasKey("HealthInsPlanId");

                    b.ToTable("HealthInsurance");
                });

            modelBuilder.Entity("BenefitsPortal.Models.LifeInsurance", b =>
                {
                    b.Property<int>("LifeInsPlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("LifeInsPlanLink")
                        .IsRequired();

                    b.Property<string>("LifeInsPlanName")
                        .IsRequired();

                    b.Property<string>("LifeInsPlanSummary")
                        .IsRequired();

                    b.HasKey("LifeInsPlanId");

                    b.ToTable("LifeInsurance");
                });

            modelBuilder.Entity("BenefitsPortal.Models.Retirement", b =>
                {
                    b.Property<int>("RetirementPlanId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("RetirementPlanLink")
                        .IsRequired();

                    b.Property<string>("RetirementPlanName")
                        .IsRequired();

                    b.Property<string>("RetirementPlanSummary")
                        .IsRequired();

                    b.HasKey("RetirementPlanId");

                    b.ToTable("Retirement");
                });

            modelBuilder.Entity("BenefitsPortal.Models.SiteDiscount", b =>
                {
                    b.Property<int>("SiteDiscountId")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("DiscountType")
                        .IsRequired();

                    b.Property<string>("Instructions")
                        .IsRequired();

                    b.Property<string>("Link")
                        .IsRequired();

                    b.Property<string>("SiteName")
                        .IsRequired();

                    b.Property<string>("Summary")
                        .IsRequired();

                    b.HasKey("SiteDiscountId");

                    b.ToTable("SiteDiscount");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole", b =>
                {
                    b.Property<string>("Id");

                    b.Property<string>("ConcurrencyStamp")
                        .IsConcurrencyToken();

                    b.Property<string>("Name")
                        .HasAnnotation("MaxLength", 256);

                    b.Property<string>("NormalizedName")
                        .HasAnnotation("MaxLength", 256);

                    b.HasKey("Id");

                    b.HasIndex("NormalizedName")
                        .HasName("RoleNameIndex");

                    b.ToTable("AspNetRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("RoleId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("AspNetRoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("ClaimType");

                    b.Property<string>("ClaimValue");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider");

                    b.Property<string>("ProviderKey");

                    b.Property<string>("ProviderDisplayName");

                    b.Property<string>("UserId")
                        .IsRequired();

                    b.HasKey("LoginProvider", "ProviderKey");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("RoleId");

                    b.HasKey("UserId", "RoleId");

                    b.HasIndex("RoleId");

                    b.HasIndex("UserId");

                    b.ToTable("AspNetUserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("UserId");

                    b.Property<string>("LoginProvider");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("UserId", "LoginProvider", "Name");

                    b.ToTable("AspNetUserTokens");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRoleClaim<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Claims")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserClaim<string>", b =>
                {
                    b.HasOne("BenefitsPortal.Models.ApplicationUser")
                        .WithMany("Claims")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserLogin<string>", b =>
                {
                    b.HasOne("BenefitsPortal.Models.ApplicationUser")
                        .WithMany("Logins")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityUserRole<string>", b =>
                {
                    b.HasOne("Microsoft.AspNetCore.Identity.EntityFrameworkCore.IdentityRole")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("BenefitsPortal.Models.ApplicationUser")
                        .WithMany("Roles")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
        }
    }
}

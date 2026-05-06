using IAP.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace IAP.Domain.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Attendance> Attendances { get; set; }

        public DbSet<User> Users { get; set; }

        public DbSet<SystemSetting> SystemSettings { get; set; }

        public DbSet<Company> Companies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Company>().HasData(
                new Company
                {
                    Name = "AECS",
                    Address = "Madurai",
                    ContactPerson = "Ram",
                    Phone = "9876543210",
                    Email = "hr@aecs.org",
                    CreatedAt = DateTime.Now,
                }
            );


            modelBuilder.Entity<User>().HasData(
                new User
                {
                    CompanyId = 1,
                    EmployeeId = "ADMIN01",
                    Name = "Aravind",
                    Email = "aravind@aecs.org",
                    PasswordHash = ByCrypt("123"),


                }

            );


        }
    }
}

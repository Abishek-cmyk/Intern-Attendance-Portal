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
                    Id = 1,
                    Name = "AECS",
                    Address = "Madurai",
                    ContactPerson = "Ram",
                    Phone = "9876543210",
                    Email = "hr@aecs.org",
                    CreatedAt = new DateTime(2026, 05, 06, 0, 0, 0, DateTimeKind.Utc)
                }
            );

            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    CompanyId = 1,
                    EmployeeId = "ADMIN01",
                    Name = "Aravind",
                    Email = "aravind@aecs.org",
                    PasswordHash = "$2a$11$to/028k1IpfyGwiJw8WX0uZxFbSyT8HP0jeQ3H6M/I/bdDzvcjmxu",
                    Role = UserRole.Admin,
                    Status = UserStatus.Active,
                    CreatedAt = new DateTime(2026, 05, 06, 0, 0, 0, DateTimeKind.Utc)
                },
                new User
                {
                    Id = 2,
                    CompanyId = 1,
                    EmployeeId = "INTERN0001",
                    Name = "Abi",
                    Email = "abi@aecs.org",
                    PasswordHash = "$2a$11$to/028k1IpfyGwiJw8WX0uZxFbSyT8HP0jeQ3H6M/I/bdDzvcjmxu",
                    Role = UserRole.Intern,
                    Status = UserStatus.Active,
                    CreatedAt = new DateTime(2026, 05, 06, 0, 0, 0, DateTimeKind.Utc)
                }


            );

            modelBuilder.Entity<SystemSetting>().HasData(
                new SystemSetting
                {
                    Id = 1,
                    CompanyId = 1,
                    CheckInStartTime = new TimeSpan(9, 0, 0),
                    CheckInEndTime = new TimeSpan(10, 0, 0),
                    CheckOutStartTime = new TimeSpan(18, 0, 0),
                    Latitude = 9.9222395m,
                    Longitude = 78.1389458m,
                    RadiusInMeters = 10,
                    CreatedAt = new DateTime(2026, 05, 06, 0, 0, 0, DateTimeKind.Utc)
                }
            );
        }
    }
}

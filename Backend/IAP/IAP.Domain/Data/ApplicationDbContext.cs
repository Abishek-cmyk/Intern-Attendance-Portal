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
    }
}

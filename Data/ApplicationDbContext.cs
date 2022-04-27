using System;
using Microsoft.EntityFrameworkCore;
using test.Models;

namespace test.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Qualification> Qualification { get; set; }
        public DbSet<EmployeeQualification> EmployeeQualification { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<EmployeeQualification>().HasKey(e => new { e.EmployeeId, e.QualificationId });
            builder.Entity<Employee>()
            .HasMany(e => e.EmployeeQualifications)
            .WithOne(e => e.Employee);

            builder.Entity<Qualification>()
            .HasMany(q => q.EmployeeQualifications)
            .WithOne(e => e.Qualification);

            builder.Entity<Employee>().ToTable("Employee");
            builder.Entity<EmployeeQualification>().ToTable("Emp_Qualification");
            builder.Entity<Qualification>().ToTable("QualificationList");
        }

    }
}

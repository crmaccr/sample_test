﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using test.Data;

namespace test.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    partial class ApplicationDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("ProductVersion", "5.0.16")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("test.Models.Employee", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Employee_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("DOB")
                        .HasColumnType("Date");

                    b.Property<DateTime>("EntryDate")
                        .HasColumnType("Date")
                        .HasColumnName("Entry_date");

                    b.Property<string>("Entry_By")
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Gender")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Emp_Name");

                    b.HasKey("Id");

                    b.ToTable("Employee");
                });

            modelBuilder.Entity("test.Models.EmployeeQualification", b =>
                {
                    b.Property<int>("EmployeeId")
                        .HasColumnType("int")
                        .HasColumnName("Employee_Id");

                    b.Property<int>("QualificationId")
                        .HasColumnType("int")
                        .HasColumnName("Q_Id");

                    b.Property<int>("Marks")
                        .HasColumnType("int");

                    b.HasKey("EmployeeId", "QualificationId");

                    b.HasIndex("QualificationId");

                    b.ToTable("Emp_Qualification");
                });

            modelBuilder.Entity("test.Models.Qualification", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("Q_Id")
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)")
                        .HasColumnName("Q_Name");

                    b.HasKey("Id");

                    b.ToTable("QualificationList");
                });

            modelBuilder.Entity("test.Models.EmployeeQualification", b =>
                {
                    b.HasOne("test.Models.Employee", "Employee")
                        .WithMany("EmployeeQualifications")
                        .HasForeignKey("EmployeeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("test.Models.Qualification", "Qualification")
                        .WithMany("EmployeeQualifications")
                        .HasForeignKey("QualificationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Employee");

                    b.Navigation("Qualification");
                });

            modelBuilder.Entity("test.Models.Employee", b =>
                {
                    b.Navigation("EmployeeQualifications");
                });

            modelBuilder.Entity("test.Models.Qualification", b =>
                {
                    b.Navigation("EmployeeQualifications");
                });
#pragma warning restore 612, 618
        }
    }
}
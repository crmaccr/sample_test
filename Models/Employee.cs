using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public enum Gender
    {
        Male = 1,
        Female = 2,
        Third = 3

    }
    public class Employee
    {
        [Column("Employee_Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Column("Emp_Name")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public string Entry_By { get; set; }

        [DataType(DataType.Date)]
        [Column("Entry_date", TypeName = "Date")]
        public DateTime EntryDate { get; set; } = DateTime.Now;

        public List<EmployeeQualification> EmployeeQualifications { get; set; }





    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public enum Gender
    {
        [Display(Name = "Male")] Male = 1,
        [Display(Name = "Female")] Female = 2,
        [Display(Name = "Third")] Third = 3

    }
    public class Employee
    {
        [Column("Employee_Id")]
        public int Id { get; set; }
        [Required]
        [StringLength(100, MinimumLength = 3)]
        [Column("Emp_Name")]
        // [RegularExpression(@"^[A - Za - z]+[\s][A - Za - z]+$", ErrorMessage = "Enter characters and single white space")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Salary { get; set; }


        public string Entry_By { get; set; }

        [DataType(DataType.Date)]
        [Column("Entry_date", TypeName = "Date")]
        public DateTime EntryDate { get; set; } = DateTime.Now;

        public List<EmployeeQualification> EmployeeQualifications { get; set; }





    }
}

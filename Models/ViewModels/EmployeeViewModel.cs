using System;
using System.ComponentModel.DataAnnotations;

namespace test.Models.ViewModels
{

    public class QualificationViewModel
    {
        [Display(Name = "Degree")]
        public int CourseId { get; set; }
        public int Marks { get; set; }

    }
    public class EmployeeViewModel
    {

        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 3)]
        [RegularExpression(@"^[A-Za-z]+[\s][A-Za-z]+$", ErrorMessage = "In Format FirstName LastName")]
        public string Name { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "yyyy’-‘MM’-‘dd’T’HH’:’mm’:’ss", ApplyFormatInEditMode = true)]
        public DateTime DOB { get; set; }
        public Gender Gender { get; set; }
        public decimal Salary { get; set; }
        public string Entry_By { get; set; }

        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; } = DateTime.Now;
        [Display(Name = "Employee Qualifications")]

        // For now assuming a employee has single Qualification
        public QualificationViewModel QualificationVm { get; set; }

    }
}

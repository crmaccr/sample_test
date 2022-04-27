using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class EmployeeQualification
    {
        [Column("Employee_Id")]
        public int EmployeeId { get; set; }
        [Column("Q_Id")]
        public int QualificationId { get; set; }
        
        [Range(1, 100, ErrorMessage = "Marks must be between 1-100")]
        public int Marks { get; set; }

        public Qualification Qualification { get; set; }
        public Employee Employee { get; set; }


    }
}

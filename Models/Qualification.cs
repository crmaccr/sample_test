using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace test.Models
{
    public class Qualification
    {
        [Column("Q_Id")]
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100, MinimumLength = 2)]
        [Column("Q_Name")]
        public string Name { get; set; }

        public List<EmployeeQualification> EmployeeQualifications { get; set; }

    }
}

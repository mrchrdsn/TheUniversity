using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace TheUniversity.Models
{
    public class Assignment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AssignmentID { get; set; }

        public int CourseID { get; set; }

        [Required]
        [Display(Name = "Assignment Description")]
        public string AssignmentDescription { get; set; }

        public int AssignmentGrade { get; set; }
    }
}

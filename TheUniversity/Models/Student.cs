using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheUniversity.Models
{
    public class Student
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int StudentID { get; set; }

        public int HomeSchoolID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length cannot be longer than 50 characters.")]
        [Display(Name = "First Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Length cannot be longer than 50 characters.")]
        [Display(Name = "Middle Name or Initial")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string MiddleName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length cannot be longer than 50 characters.")]
        [Display(Name = "Last Name")]
        [RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string LastName { get; set; }

        [Required]
        [Display(Name = "Grade Level")]
        public string GradeLevel { get; set; }

        [Required]
        [Display(Name = "Enrollment Date")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd-MMM-yyyy}", ApplyFormatInEditMode = true)]
        public DateTime EnrollDate { get; set; }

        public HomeSchool School { get; set; }

        public ICollection<Course> Courses { get; set; }
    }
}

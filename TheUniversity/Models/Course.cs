using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TheUniversity.Models
{
    public class Course
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int CourseID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Length cannot be longer than 50 characters.")]
        [Display(Name = "Course Name")]
        public string Title { get; set; }

        [Required]
        public string Description { get; set; }

        public int Credits { get; set; }

        public double CourseAverage { get; set; }

        public double CourseGradePointAverage { get; set; }

        public ICollection<Enrollment> Enrollments { get; }

        public ICollection<Assignment> Assignments { get; }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Data;
using TheUniversity.Models;
using TheUniversity.Utilities;

namespace TheUniversity.Pages.Students
{
    public class DetailsModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public DetailsModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Student Student { get; set; }

        public IActionResult OnGet(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            GetBaseStudentInformation(id);

            if (Student == null)
            {
                return NotFound();
            }

            GradeRetriever gradeRetriever = new GradeRetriever(Student);
            List<double> gradesList = gradeRetriever.GetStudentGradeList(id);

            if (gradesList.Count > 0)
            {
                Student.OverallAverage = GetStudentOverallAverage(gradesList);
                Student.OverallGradePointAverage = GetStudentGradePointAverage(gradesList);
            }
            else
            {
                Student.OverallAverage = double.NaN;
                Student.OverallGradePointAverage = double.NaN;
            }

            Student.School = _context.HomeSchool
                .Where(x => x.HomeSchoolID == Student.HomeSchoolID)
                .FirstOrDefault();

            //GetStudentSchool();

            return Page();
        }

        private void GetBaseStudentInformation(int? id)
        {
            Student = _context.Student
                .Include(e => e.Enrollments)
                .ThenInclude(c => c.Course)
                .ThenInclude(a => a.Assignments)
                .FirstOrDefault(m => m.StudentID == id);
        }

        private List<double> GetStudentGradeList(int? id)
        {
            List<Course> courses = new List<Course>();
            List<Assignment> assignments = new List<Assignment>();
            List<double> studentGrades = new List<double>();

            courses = Student.Courses.Where(x => Student.StudentID == id).ToList();

            assignments = courses.SelectMany(x => x.Assignments).ToList();

            studentGrades = assignments.Select(x => (double)x.AssignmentGrade).ToList();

            return studentGrades;
        }

        private double GetStudentOverallAverage(List<double> gradesList)
        {
            ICalculator averageCalculator = new AverageCalculator(gradesList);

            return averageCalculator.Calculate();
        }

        private double GetStudentGradePointAverage(List<double> gradesList)
        {
            double average = GetStudentOverallAverage(gradesList);

            ICalculator gradePointAverageCalculator = new GradePointAverageCalculator(average);

            return gradePointAverageCalculator.Calculate();
        }

        private async void GetStudentSchool()
        {
            Student.School = await _context.HomeSchool
                .Where(x => x.HomeSchoolID == Student.HomeSchoolID)
                .FirstOrDefaultAsync();
        }
    }
}
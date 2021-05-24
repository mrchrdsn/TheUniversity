using System.Collections.Generic;
using System.Linq;
using TheUniversity.Models;

namespace TheUniversity.Utilities
{
    public class GradeRetriever
    {
        Student _student;
        private List<Course> _courses = new List<Course>();
        private List<Assignment> _assignments = new List<Assignment>();
        List<double> _studentGrades = new List<double>();
        public GradeRetriever(Student student)
        {
            _student = student;
        }

        public List<double> GetStudentGradeList(int? studentId)
        {
            _courses = _student.Courses.Where(x => _student.StudentID == studentId).ToList();

            _assignments = _courses.SelectMany(x => x.Assignments).ToList();

            _studentGrades = _assignments.Select(x => (double)x.AssignmentGrade).ToList();

            return _studentGrades;
        }

        public List<Course> GetCourseGradeListByStudentId(int? studentId)
        {
            _courses = _student.Courses.Where(x => _student.StudentID == studentId).ToList();
            int courseId = 0;
            List<Course> courseList = new List<Course>();

            foreach (Course course in _courses)
            {
                course.CourseAverage = GetCourseAverageByCourseAndStudent(studentId, course.CourseID);
            }

            return courseList;
        }

        private double GetCourseAverageByCourseAndStudent(int? studentId, int courseId)
        {
            _assignments = _courses.SelectMany(x => x.Assignments).ToList();
            List<double> gradeList = new List<double>();
            double courseAverage = 0;

            gradeList = _assignments.Where(x => x.CourseID == courseId)
                .Select(x => (double)x.AssignmentGrade).ToList();

            return courseAverage = gradeList.Average();
        }
    }
}

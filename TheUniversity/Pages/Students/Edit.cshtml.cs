using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Models;

namespace TheUniversity.Pages.Students
{
    public class EditModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public EditModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Student Student { get; set; }

        [BindProperty]
        public ICollection<Course> CourseCollection { get; set; }

        [BindProperty]
        public List<int> CourseList { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Student = await _context.Student.FirstOrDefaultAsync(m => m.StudentID == id);
            CourseCollection = await _context.Course.ToListAsync<Course>();

            if (Student == null)
            {
                return NotFound();
            }
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            List<int> courseList = CourseList.ToList();

            foreach (var courseId in courseList)
            {
                Enrollment enrollment = new Enrollment();
                enrollment.StudentID = Student.StudentID;
                enrollment.CourseID = courseId;

                _context.Enrollment.Add(enrollment);
                _context.SaveChanges();
            }

            _context.Attach(Student).State = EntityState.Modified;

            try
            {
                _context.Student.Update(Student);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(Student.StudentID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private void SaveCourseEnrollments()
        {
            List<int> courseList = CourseList.ToList();

            foreach (var courseId in courseList)
            {
                Enrollment enrollment = new Enrollment();
                enrollment.StudentID = Student.StudentID;
                enrollment.CourseID = courseId;

                _context.Enrollment.Add(enrollment);
                _context.SaveChanges();
            }
        }

        private bool StudentExists(int id)
        {
            return _context.Student.Any(e => e.StudentID == id);
        }
    }
}

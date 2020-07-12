using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUniversity.Data;
using TheUniversity.Models;

namespace TheUniversity.Pages.Enrollments
{
    public class CreateModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public CreateModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["CourseID"] = new SelectList(_context.Course, "CourseID", "Description");
        ViewData["StudentID"] = new SelectList(_context.Student, "StudentID", "FirstName");
            return Page();
        }

        [BindProperty]
        public Enrollment Enrollment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Enrollment.Add(Enrollment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

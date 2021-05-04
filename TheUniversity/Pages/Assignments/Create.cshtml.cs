using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using TheUniversity.Models;
using System.Linq;

namespace TheUniversity.Pages.Assignments
{
    public class CreateModel : PageModel
    {
        private readonly Data.SchoolContext _context;

        public CreateModel(Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet(int? id)
        {
            string courseName = _context.Course
                .Where(x => x.CourseID == id)
                .Select(y => y.Title)
                .FirstOrDefault();

            ViewData["CourseName"] = courseName;

            return Page();
        }

        [BindProperty]
        public Assignment Assignment { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Assignment.Add(Assignment);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

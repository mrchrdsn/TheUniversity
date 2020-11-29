using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Models;
using TheUniversity.Utilities;

namespace TheUniversity.Pages.Students
{
    public class IndexModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public IndexModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; }

        public async Task OnGetAsync()
        {
            //PdfTranscript transcript = new PdfTranscript();
            //transcript.GetTranscript();

            Student = await _context.Student
                .Include(e => e.Enrollments)
                .ThenInclude(c => c.Course)
                .ToListAsync();
        }
    }
}

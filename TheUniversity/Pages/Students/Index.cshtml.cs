using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using PdfSharpCore.Drawing;
using PdfSharpCore.Pdf;
using TheUniversity.Data;
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
            PdfTranscript transcript = new PdfTranscript();
            transcript.GetTranscript();

            //Student = await _context.Student.ToListAsync();
            Student = await _context.Student
                .Include(h => h.School)
                .Include(c => c.Courses).ToListAsync();
        }
    }
}

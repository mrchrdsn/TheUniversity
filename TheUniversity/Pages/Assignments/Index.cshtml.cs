using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Models;

namespace TheUniversity.Pages.Assignments
{
    public class IndexModel : PageModel
    {
        private readonly Data.SchoolContext _context;

        public IndexModel(Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<Assignment> Assignments { get; set; }

        public async Task OnGetAsync(int? id)
        {
            Assignments = await _context.Assignment
                .Where(x => x.CourseID == id)
                .ToListAsync();
        }
    }
}
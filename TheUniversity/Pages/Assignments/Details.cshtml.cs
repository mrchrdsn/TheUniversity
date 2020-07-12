using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Data;
using TheUniversity.Models;

namespace TheUniversity.Pages.Assignments
{
    public class DetailsModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public DetailsModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public Assignment Assignment { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Assignment = await _context.Assignment.FirstOrDefaultAsync(m => m.AssignmentID == id);

            if (Assignment == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

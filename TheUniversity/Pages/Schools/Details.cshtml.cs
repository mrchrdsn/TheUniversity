using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Data;
using TheUniversity.Models;

namespace TheUniversity.Pages.Schools
{
    public class DetailsModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public DetailsModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public HomeSchool HomeSchool { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            //HomeSchool = await _context.HomeSchool.FirstOrDefaultAsync(m => m.HomeSchoolID == id);
            HomeSchool = await _context.HomeSchool
                .Include(h => h.Administrator).FirstOrDefaultAsync(m => m.HomeSchoolID == id);

            if (HomeSchool == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}

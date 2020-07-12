using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Data;
using TheUniversity.Models;

namespace TheUniversity.Pages.Schools
{
    public class EditModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public EditModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
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
           ViewData["AdministratorID"] = new SelectList(_context.SchoolAdministrator, "SchoolAdministratorID", "Email");
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

            _context.Attach(HomeSchool).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HomeSchoolExists(HomeSchool.HomeSchoolID))
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

        private bool HomeSchoolExists(int id)
        {
            return _context.HomeSchool.Any(e => e.HomeSchoolID == id);
        }
    }
}

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

namespace TheUniversity.Pages.SchoolAdmin
{
    public class EditModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public EditModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        [BindProperty]
        public SchoolAdministrator SchoolAdministrator { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolAdministrator = await _context.SchoolAdministrator.FirstOrDefaultAsync(m => m.SchoolAdministratorID == id);

            if (SchoolAdministrator == null)
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

            _context.Attach(SchoolAdministrator).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolAdministratorExists(SchoolAdministrator.SchoolAdministratorID))
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

        private bool SchoolAdministratorExists(int id)
        {
            return _context.SchoolAdministrator.Any(e => e.SchoolAdministratorID == id);
        }
    }
}

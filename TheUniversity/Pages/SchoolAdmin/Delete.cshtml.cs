using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Data;
using TheUniversity.Models;

namespace TheUniversity.Pages.SchoolAdmin
{
    public class DeleteModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public DeleteModel(TheUniversity.Data.SchoolContext context)
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

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            SchoolAdministrator = await _context.SchoolAdministrator.FindAsync(id);

            if (SchoolAdministrator != null)
            {
                _context.SchoolAdministrator.Remove(SchoolAdministrator);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

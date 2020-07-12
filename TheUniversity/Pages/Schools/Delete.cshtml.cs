using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using TheUniversity.Models;

namespace TheUniversity.Pages.Schools
{
    public class DeleteModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public DeleteModel(TheUniversity.Data.SchoolContext context)
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
                .Include(h => h.Administrator)
                .FirstOrDefaultAsync(m => m.HomeSchoolID == id);

            if (HomeSchool == null)
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

            HomeSchool = await _context.HomeSchool.FindAsync(id);

            if (HomeSchool != null)
            {
                _context.HomeSchool.Remove(HomeSchool);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

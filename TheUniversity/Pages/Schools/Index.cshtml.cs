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
    public class IndexModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public IndexModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<HomeSchool> HomeSchool { get;set; }


        public async Task OnGetAsync()
        {
            HomeSchool = await _context.HomeSchool
                .Include(h => h.Administrator).ToListAsync();
        }
    }
}

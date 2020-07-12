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
    public class IndexModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public IndexModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IList<SchoolAdministrator> SchoolAdministrator { get;set; }

        public async Task OnGetAsync()
        {
            SchoolAdministrator = await _context.SchoolAdministrator.ToListAsync();
        }
    }
}

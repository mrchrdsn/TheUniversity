﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using TheUniversity.Data;
using TheUniversity.Models;

namespace TheUniversity.Pages.Schools
{
    public class CreateModel : PageModel
    {
        private readonly TheUniversity.Data.SchoolContext _context;

        public CreateModel(TheUniversity.Data.SchoolContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["AdministratorID"] = new SelectList(_context.SchoolAdministrator, "SchoolAdministratorID", "LastName");
            return Page();
        }

        [BindProperty]
        public HomeSchool HomeSchool { get; set; }

        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.HomeSchool.Add(HomeSchool);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

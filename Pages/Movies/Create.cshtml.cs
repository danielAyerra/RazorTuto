using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazorTuto.Data;
using RazorTuto.Models;

namespace RazorTuto.Pages.Movies
{
    public class CreateModel : PageModel
    {
        private readonly DbContext? _context;

        public CreateModel( IWebHostEnvironment env, RazorPagesMovieContextMariaDb? contextMariaDb=null, RazorPagesMovieContextSqLite? contextSqLite=null)
        {
            _context = env.IsDevelopment() ? contextSqLite : contextMariaDb;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        // For more information, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Set<Movie>().Add(Movie);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}

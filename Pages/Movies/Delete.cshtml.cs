using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazorTuto.Data;
using RazorTuto.Models;

namespace RazorTuto.Pages.Movies
{
    public class DeleteModel : PageModel
    {
        private readonly DbContext _context;

        public DeleteModel(IWebHostEnvironment env, RazorPagesMovieContextSqLite? contextSqLite=null, RazorPagesMovieContextMariaDb? contextMariaDB=null)
        {
            _context = env.IsDevelopment()?contextSqLite:contextMariaDB;
        }

        [BindProperty]
        public Movie Movie { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Set<Movie>().FirstOrDefaultAsync(m => m.Id == id);

            if (movie is not null)
            {
                Movie = movie;

                return Page();
            }

            return NotFound();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var movie = await _context.Set<Movie>().FindAsync(id);
            if (movie != null)
            {
                Movie = movie;
                _context.Set<Movie>().Remove(Movie);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}

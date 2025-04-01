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
    public class IndexModel : PageModel
    {
        private readonly DbContext _context;

        public IndexModel(IWebHostEnvironment env, RazorPagesMovieContextSqLite? contextSqLite=null, RazorPagesMovieContextMariaDb? contextMariaDB=null)
        {
            _context = env.IsDevelopment()?contextSqLite:contextMariaDB;
        }

        public IList<Movie> Movie { get;set; } = default!;

        public async Task OnGetAsync()
        {
            DbSet<Movie> movieDb = _context.Set<Movie>();
            IQueryable<string> genreQuery = from m in movieDb
                orderby m.Genre
                select m.Genre;
            
            var movies = from m in movieDb
                select m;
            if (!string.IsNullOrEmpty(SearchString))
            {
                movies = movies.Where(s => s.Title!.Contains(SearchString));
            }
            
            if (!string.IsNullOrEmpty(MovieGenre))
            {
                movies = movies.Where(x => x.Genre == MovieGenre);
            }

            Genres = new SelectList(await genreQuery.Distinct().ToListAsync());

            Movie = await movies.ToListAsync();
        }
        
        [BindProperty(SupportsGet = true)]
        public string? SearchString { get; set; }

        public SelectList? Genres { get; set; }

        [BindProperty(SupportsGet = true)]
        public string? MovieGenre { get; set; }
    }
}

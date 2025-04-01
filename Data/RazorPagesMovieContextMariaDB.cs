using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using RazorTuto.Models;

namespace RazorTuto.Data;

public class RazorPagesMovieContextMariaDb : DbContext
{
    public RazorPagesMovieContextMariaDb (DbContextOptions<RazorPagesMovieContextMariaDb> options)
        : base(options)
    {
    }

    public DbSet<RazorTuto.Models.Movie> Movie { get; set; } = default!;
}
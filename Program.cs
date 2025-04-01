using Microsoft.AspNetCore.Hosting.StaticWebAssets;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Pomelo.EntityFrameworkCore.MySql.Infrastructure;
using RazorTuto.Data;
using RazorTuto.Models;

var builder = WebApplication.CreateBuilder(args);
if (!builder.Environment.IsDevelopment())
{
    StaticWebAssetsLoader.UseStaticWebAssets(builder.Environment, builder.Configuration);
}

// Add services to the container.
builder.Services.AddRazorPages();
if (builder.Environment.IsDevelopment())
{
    builder.Services.AddDbContext<RazorPagesMovieContextSqLite>(options =>
        options.UseSqlite(builder.Configuration.GetConnectionString("RazorPagesMovieContext")?? throw new InvalidOperationException("Connection string 'RazorPagesMovieContext' not found.")));;
}
else
{
    builder.Services.AddDbContext<RazorPagesMovieContextMariaDb>(options =>
        options.UseMySql(
            builder.Configuration.GetConnectionString("RazorPagesMovieContext"),
            new MySqlServerVersion(new Version(11, 4, 5)) // Adjust to your MariaDB version
        ));
}

var app = builder.Build();

//app.UseRequestLocalization("es-ES");
if (builder.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;
        SeedData.Initialize(services);
    }
}

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseRouting();

app.UseAuthorization();

app.MapStaticAssets();
app.MapRazorPages()
    .WithStaticAssets();

app.UseRequestLocalization("es-ES");

app.Run();
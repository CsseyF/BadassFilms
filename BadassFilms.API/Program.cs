using BadassFilms.Core.Entities;
using BadassFilms.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<BadassFilmsContext>(opt => opt.UseInMemoryDatabase("Movies"));

var app = builder.Build();

app.MapGet("/", () => "Hello World!");

app.MapGet("/movies", async (BadassFilmsContext context) => await context.Movies.ToListAsync());

app.MapPost("/movies", async (Movie movie, BadassFilmsContext dbContext, HttpContext httpContext) =>
{
    movie.CreatorIp = httpContext.Connection.RemoteIpAddress?.ToString();
    dbContext.Movies.Add(movie);
    await dbContext.SaveChangesAsync();

    return Results.Created($"/movies/{movie.Id}", movie);
});


app.Run();

using api.Models;
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddScoped<ISqliteRepo,SqliteRepo>();
var app = builder.Build();

app.MapGet("/films", (ISqliteRepo repo) =>
{
    return repo.GetAllFilms();
});
app.MapGet("/films/{id}", (ISqliteRepo repo, int id) =>
{
    var film = repo.GetFilm(id);
    if (film == null)
    {
        return Results.NotFound();
    }
    return Results.Ok(film);
});
app.MapPost("/films", (ISqliteRepo repo, Film film) =>
{
    repo.AddFilm(film);
    return Results.Created($"/films/{film.Id}", film);
});
app.MapDelete("/films/{id}", (ISqliteRepo repo, int id) =>
{
    var film = repo.GetFilm(id);
    if (film == null)
    {
        return Results.NotFound();
    }
    repo.DeleteFilm(id);
    return Results.NoContent();
});

app.MapPut("/films/{id}", (ISqliteRepo repo, int id, Film updatedFilm) =>
{
    var film = repo.GetFilm(id);
    if (film == null)
    {
        return Results.NotFound();
    }
    film.Title = updatedFilm.Title;
    film.Director = updatedFilm.Director;
    film.Year = updatedFilm.Year;
    repo.UpdateFilm(film);
    return Results.NoContent();
});
app.Run();

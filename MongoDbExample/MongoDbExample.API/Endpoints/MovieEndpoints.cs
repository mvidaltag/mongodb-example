using MongoDbExample.Data.Models;
using MongoDbExample.Data.Repositories;
using MongoDbExampleAPI.Endpoints.DTOs;

namespace MongoDbExampleAPI.Endpoints;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this WebApplication app)
    {
        app.MapGet("/", () => "hello world!");

        app.MapGet("/movies", async (IMovieRepository repo) =>
        {
            var movies = await repo.GetAllAsync();
            var output = movies.Select(CustomMapper.ToOutputDto);
            return Results.Ok(output);
        });

        app.MapGet("/movies/{id}", async (string id, IMovieRepository repo) =>
        {
            var movie = await repo.GetByIdAsync(id);
            if (movie is null) return Results.NotFound();
            var output = CustomMapper.ToOutputDto(movie);
            return Results.Ok(output);
        });

        app.MapPost("/movies", async (MovieInputDto input, IMovieRepository repo) =>
        {
            var movie = CustomMapper.ToMovie(input);
            await repo.AddAsync(movie);
            var output = CustomMapper.ToOutputDto(movie);
            return Results.Created($"/movies/{movie.Id}", output);
        });

        app.MapPut("/movies/", async (MovieDto input, IMovieRepository repo) =>
        {
            var movie = CustomMapper.ToMovie(input);
            await repo.UpdateAsync(movie);
            return Results.NoContent();
        });

        app.MapDelete("/movies/{id}", async (string id, IMovieRepository repo) =>
        {
            await repo.DeleteAsync(id);
            return Results.NoContent();
        });
    }
}
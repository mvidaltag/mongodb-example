using MongoDbExample.Data.Models;
using MongoDbExample.Data.Repositories;
using MongoDbExampleAPI.Endpoints.DTOs;

namespace MongoDbExampleAPI.Endpoints;

public static class MovieEndpoints
{
    public static void MapMovieEndpoints(this WebApplication app)
    {
        app.MapGet("/movies", async (IMovieRepository repo) =>
        {
            var movies = await repo.GetAllAsync();
            var output = movies.Select(CustomMapper.ToOutputDto);
            return Results.Ok(output);
        })
        .WithName("GetAllMovies")
        .WithTags("Movies")
        .WithSummary("Lists all movies")
        .Produces<IEnumerable<MovieOutputDto>>(StatusCodes.Status200OK);

        app.MapGet("/movies/{id}", async (string id, IMovieRepository repo) =>
        {
            var movie = await repo.GetByIdAsync(id);
            if (movie is null) return Results.NotFound();
            var output = CustomMapper.ToOutputDto(movie);
            return Results.Ok(output);
        })
        .WithName("GetMovieById")
        .WithTags("Movies")
        .WithSummary("Gets a movie by its ID")
        .Produces<MovieOutputDto>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status404NotFound);

        app.MapPost("/movies", async (MovieInputDto input, IMovieRepository repo) =>
        {
            var movie = CustomMapper.ToMovie(input);
            await repo.AddAsync(movie);
            var output = CustomMapper.ToOutputDto(movie);
            return Results.Created($"/movies/{movie.Id}", output);
        })
        .WithName("CreateMovie")
        .WithTags("Movies")
        .WithSummary("Creates a new movie")
        .Produces<MovieOutputDto>(StatusCodes.Status201Created);

        app.MapPut("/movies/", async (MovieDto input, IMovieRepository repo) =>
        {
            var movie = CustomMapper.ToMovie(input);
            await repo.UpdateAsync(movie);
            return Results.NoContent();
        })
        .WithName("UpdateMovie")
        .WithTags("Movies")
        .WithSummary("Updates an existing movie")
        .Produces(StatusCodes.Status204NoContent);

        app.MapDelete("/movies/{id}", async (string id, IMovieRepository repo) =>
        {
            await repo.DeleteAsync(id);
            return Results.NoContent();
        })
        .WithName("DeleteMovie")
        .WithTags("Movies")
        .WithSummary("Deletes a movie by its ID")
        .Produces(StatusCodes.Status204NoContent);
    }
}
using MongoDbExample.Data.Models;
using MongoDbExampleAPI.Endpoints.DTOs;

namespace MongoDbExampleAPI.Endpoints;

public static class CustomMapper
{
    public static MovieOutputDto ToOutputDto(Movie movie)
    {
        return new MovieOutputDto
        {
            Id = movie.Id,
            Title = movie.Title,
            Director = movie.Director,
            Year = movie.Year,
            Genres = movie.Genres,
            Rating = movie.Rating
        };
    }

    public static Movie ToMovie(MovieInputDto input)
    {
        return new Movie
        {
            Title = input.Title,
            Director = input.Director,
            Year = input.Year,
            Genres = input.Genres,
            Rating = input.Rating
        };
    }
    
    public static Movie ToMovie(MovieDto input)
    {
        return new Movie
        {
            Id = input.Id,
            Title = input.Title,
            Director = input.Director,
            Year = input.Year,
            Genres = input.Genres,
            Rating = input.Rating
        };
    }
}
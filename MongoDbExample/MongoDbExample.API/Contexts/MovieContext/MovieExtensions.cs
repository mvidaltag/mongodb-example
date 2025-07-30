using MongoDbExample.Data.Contexts;
using MongoDbExample.Data.Repositories;

namespace MongoDbExampleAPI.Contexts.MovieContext;

public static class MovieExtensions
{
    public static WebApplicationBuilder AddMovieContext(this WebApplicationBuilder builder)
    {
        builder.Services.AddSingleton<IMovieContext, MongoDbExample.Data.Contexts.MovieContext>();
        builder.Services.AddScoped<IMovieRepository, MovieRepository>();
        return builder;
    }
}
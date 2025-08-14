using MongoDB.Driver;
using MongoDbExample.Data.Models;
using Microsoft.Extensions.Configuration;

namespace MongoDbExample.Data.Contexts;

public class MovieContext : IMovieContext
{
    private readonly IMongoDatabase _database;

    public MovieContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        _database = client.GetDatabase("MongoReview");
    }

    public IMongoCollection<Movie> Movies => _database.GetCollection<Movie>("movies");
}
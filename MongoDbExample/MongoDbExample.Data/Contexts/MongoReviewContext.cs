using MongoDB.Driver;
using MongoDbExample.Data.Models;
using Microsoft.Extensions.Configuration;

namespace MongoDbExample.Data.Contexts;

public class MongoReviewContext : IMongoReviewContext
{
    private readonly IMongoDatabase _database;

    public MongoReviewContext(IConfiguration config)
    {
        var client = new MongoClient(config.GetConnectionString("MongoDb"));
        _database = client.GetDatabase("MongoReview");
    }

    public IMongoCollection<Movie> Movies => _database.GetCollection<Movie>("movies");
}
using MongoDB.Driver;
using MongoDbExample.Data.Models;

namespace MongoDbExample.Data.Contexts;

public interface IMongoReviewContext
{
    IMongoCollection<Movie> Movies { get; }
}
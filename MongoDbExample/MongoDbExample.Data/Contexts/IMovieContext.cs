using MongoDB.Driver;
using MongoDbExample.Data.Models;

namespace MongoDbExample.Data.Contexts;

public interface IMovieContext
{
    IMongoCollection<Movie> Movies { get; }
}
using MongoDB.Driver;
using MongoDbExample.Data.Contexts;
using MongoDbExample.Data.Models;

namespace MongoDbExample.Data.Repositories;

public class MovieRepository : IMovieRepository
{
    private readonly IMongoReviewContext _context;

    public MovieRepository(IMongoReviewContext context)
    {
        _context = context;
    }

    public async Task<List<Movie>> GetAllAsync()
    {
        return await _context.Movies.Find(_ => true).ToListAsync();
    }

    public async Task<Movie?> GetByIdAsync(string id)
    {
        return await _context.Movies.Find(m => m.Id == id).FirstOrDefaultAsync();
    }

    public async Task AddAsync(Movie movie)
    {
        movie.Id = MongoDB.Bson.ObjectId.GenerateNewId().ToString();
        await _context.Movies.InsertOneAsync(movie);
    }
    
    public async Task UpdateAsync(Movie movie)
    {
        await _context.Movies.ReplaceOneAsync(m => m.Id == movie.Id, movie);
    }

    public async Task DeleteAsync(string id)
    {
        await _context.Movies.DeleteOneAsync(m => m.Id == id);
    }
}
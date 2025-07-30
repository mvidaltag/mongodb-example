using MongoDbExampleAPI.Contexts.MovieContext;
using MongoDbExampleAPI.Endpoints;

var builder = WebApplication.CreateBuilder(args);

builder.AddArchitectures();
builder.AddMovieContext();

var app = builder.Build();

app.MapMovieEndpoints();
app.UseArchitectures();

app.Run();
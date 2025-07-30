namespace MongoDbExampleAPI.Endpoints.DTOs;

public class MovieInputDto
{
    public string Title { get; set; } = string.Empty;
    public string Director { get; set; } = string.Empty;
    public int Year { get; set; }

    public List<string> Genres { get; set; } = new();
    public double Rating { get; set; }
}
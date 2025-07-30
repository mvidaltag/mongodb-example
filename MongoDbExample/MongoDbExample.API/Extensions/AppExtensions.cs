namespace MongoDbExampleAPI.Extensions;

public static class AppExtensions
{
    public static void UseArchitectures(this WebApplication app)
    {
        app.MapControllers();
        
        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.MapControllers();
    }
}
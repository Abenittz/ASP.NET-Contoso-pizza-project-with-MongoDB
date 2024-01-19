using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

public class Startup
{
    public IConfiguration Configuration { get; }

    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // MongoDB Configuration
        var connectionString = Configuration.GetConnectionString("MongoDBConnection");
        services.AddSingleton<IMongoClient>(new MongoClient(connectionString));

        // Other configurations...
    }
}

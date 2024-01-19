using System.Reflection.Metadata.Ecma335;
using ContosoPizza.Models;
using MongoDB.Driver;
using Microsoft.Extensions.Options;

namespace ContosoPizza.Services;

public class PizzaService 
{
   
    private readonly IMongoCollection<Pizza> _PizzaCollection;

    public PizzaService(
        IOptions<PizzaDatabaseSettings> PizzaDatabaseSettings)
    {
        var mongoClient = new MongoClient(
           PizzaDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
           PizzaDatabaseSettings.Value.DatabaseName);

        _PizzaCollection = mongoDatabase.GetCollection<Pizza>(
           PizzaDatabaseSettings.Value.PizzaCollectionName);
    }

    public async Task<List<Pizza>> GetAsync() =>
        await _PizzaCollection.Find(_ => true).ToListAsync();

    public async Task<Pizza?> GetAsync(String id) =>
        await _PizzaCollection.Find(x => x.Id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(Pizza newPizza) =>
        await _PizzaCollection.InsertOneAsync(newPizza);

    public async Task UpdateAsync(string id, Pizza updatedPizza) =>
        await _PizzaCollection.ReplaceOneAsync(x => x.Id == id, updatedPizza);

    public async Task RemoveAsync(string id) =>
        await _PizzaCollection.DeleteOneAsync(x => x.Id == id);
}


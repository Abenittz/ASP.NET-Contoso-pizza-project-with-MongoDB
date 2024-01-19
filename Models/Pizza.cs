using System.Text.Json.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ContosoPizza.Models;
public class Pizza
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    [JsonPropertyName("Name")]
     public String? Name { get; set; }    
    public bool IsGlutenFree { get; set; }      
}


public class PizzaDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string PizzaCollectionName { get; set; } = null!;
}


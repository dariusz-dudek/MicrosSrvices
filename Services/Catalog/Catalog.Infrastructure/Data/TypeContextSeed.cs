using System.Text.Json;
using Catalog.Core.Entities;
using MongoDB.Driver;

namespace Catalog.Infrastructure.Data;

public static class TypeContextSeed
{
    public static void SeedData(IMongoCollection<ProductType> productCollection)
    {
        bool checkTypes = productCollection.Find(type => true).Any();

        string path = Path.Combine("Data", "SeedData", "types.json");

        if(!checkTypes)
        {
            var typesData = File.ReadAllText(path);
            var products = JsonSerializer.Deserialize<List<ProductType>>(typesData);
            if(products != null)
            {
                foreach(var item in products)
                {
                    productCollection.InsertOneAsync(item);
                }
            }
        }
    }
}

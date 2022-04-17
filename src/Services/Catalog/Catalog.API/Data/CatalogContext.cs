using Catalog.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System;


namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration.GetValue<string>("DatabaseSetting:ConnectionString"));
            var database = client.GetDatabase(configuration.GetValue<string>("DatabaseSetting:DatabaseName"));

            Products = database.GetCollection<Product>(configuration.GetValue<string>("DatabaseSetting:CollectionName"));
        }
        public IMongoCollection<Product> Products { get; }
    }
}

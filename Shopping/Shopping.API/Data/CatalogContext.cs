﻿using Shopping.API.Entities;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace Shopping.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        public CatalogContext(IConfiguration config)
        {
            // used to create connection with mongo database
            var client = new MongoClient(config.GetValue<string>("DatabaseSettings:ConnectionString"));
            var database = client.GetDatabase(config.GetValue<string>("DatabaseSettings:DatabaseName"));

            Products = database.GetCollection<Product>(config.GetValue<string>("DatabaseSettings:CollectionName"));
            CatalogContextSeed.SeedData(Products);
        }

        public IMongoCollection<Product> Products { get; }
    }
}

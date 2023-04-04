using Shopping.API.Entities;
using MongoDB.Driver;

namespace Shopping.API.Data
{
    public interface ICatalogContext
    {
        IMongoCollection<Product> Products { get; }
    }
}

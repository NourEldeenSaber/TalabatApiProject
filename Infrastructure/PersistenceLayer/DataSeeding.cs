

using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System.Text.Json;

namespace PersistenceLayer
{
    public class DataSeeding (StoreDbContext _storeDbContext): IDataSeeding
    {
        public void DataSeed()
        {
            // Check if there are any pending migrations, and apply them automatically if found.
            if (_storeDbContext.Database.GetPendingMigrations().Any())
            {
                _storeDbContext.Database.Migrate();
            }

            try
            {
                if (!_storeDbContext.ProductBrands.Any())
                {
                    var productBrandData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\brands.json");
                    //convert string to c# object
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandData);
                    if (brands is not null && brands.Any())
                    {
                        _storeDbContext.ProductBrands.AddRange(brands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var productTypeData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\types.json");
                    //convert string to c# object
                    var types = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);
                    if (types is not null && types.Any())
                    {
                        _storeDbContext.ProductTypes.AddRange(types);
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var productData = File.ReadAllText(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\products.json");
                    //convert string to c# object
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);
                    if (products is not null && products.Any())
                    {
                        _storeDbContext.Products.AddRange(products);
                    }
                }

                _storeDbContext.SaveChanges();
            }
            catch (Exception ex) { 
                //ToDo
            }
            

        }
    }
}

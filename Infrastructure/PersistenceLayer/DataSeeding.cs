

using DomainLayer.Contracts;
using DomainLayer.Models;
using Microsoft.EntityFrameworkCore;
using PersistenceLayer.Data;
using System.Text.Json;

namespace PersistenceLayer
{
    public class DataSeeding (StoreDbContext _storeDbContext): IDataSeeding
    {
        public async Task DataSeedAsync()
        {
            // Check if there are any pending migrations, and apply them automatically if found.
            if ((await _storeDbContext.Database.GetPendingMigrationsAsync()).Any())
            {
               await _storeDbContext.Database.MigrateAsync();
            }

            try
            {
                if (!_storeDbContext.ProductBrands.Any())
                {
                    //var productBrandData = await File.ReadAllTextAsync(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\brands.json");
                    var productBrandData =  File.OpenRead(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\brands.json");
                    //convert string to c# object
                    var brands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandData);
                    if (brands is not null && brands.Any())
                    {
                       await _storeDbContext.ProductBrands.AddRangeAsync(brands);
                    }
                }

                if (!_storeDbContext.ProductTypes.Any())
                {
                    var productTypeData = File.OpenRead(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\types.json");
                    //convert string to c# object
                    var types = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypeData);
                    if (types is not null && types.Any())
                    {
                        await _storeDbContext.ProductTypes.AddRangeAsync(types);
                    }
                }

                if (!_storeDbContext.Products.Any())
                {
                    var productData = File.OpenRead(@"..\Infrastructure\PersistenceLayer\Data\DataSeed\products.json");
                    //convert string to c# object
                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productData);
                    if (products is not null && products.Any())
                    {
                        await _storeDbContext.Products.AddRangeAsync(products);
                    }
                }

                await _storeDbContext.SaveChangesAsync();
            }
            catch (Exception ex) { 
                //ToDo
            }
            

        }
    }
}

using Shared;
using Shared.DTOS;

namespace ServiceAbstractionLayer
{
    public interface IProductService
    {
        // Get All Products
        Task<IEnumerable<ProductDto>> GetAllProductAsync(ProductQueryParams queryParams);

        // Get Product By Id
        Task<ProductDto> GetProductByIdAsync(int id);

        // Get All Types
        Task<IEnumerable<TypeDto>> GetAllTypesAsync();

        // Get All Brands
        Task<IEnumerable<BrandDto>> GetAllBrandsAsync();

    }
}

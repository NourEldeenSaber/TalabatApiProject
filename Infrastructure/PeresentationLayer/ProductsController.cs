using Microsoft.AspNetCore.Mvc;
using ServiceAbstractionLayer;
using Shared;
using Shared.DTOS;
using System.Threading.Tasks;

namespace PeresentationLayer
{
    [ApiController]
    [Route("api/[Controller]")]
    public class ProductsController (IServiceManager _serviceManager): ControllerBase
    {
        // Get All Products
        [HttpGet] // Get :: BaseUrl/api/Products
        public async Task<ActionResult<IEnumerable<ProductDto>>> GetAllProducts([FromQuery]ProductQueryParams queryParams)
        {
            var products = await _serviceManager.ProductService.GetAllProductAsync(queryParams);
            return Ok(products);
        }

        // Get Product By Id 
        [HttpGet("{id}")] //Get :: BaseUrl/api/Products/4
        public async Task<ActionResult<ProductDto>> GetProductById(int id)
        {
            var product = await _serviceManager.ProductService.GetProductByIdAsync(id);
            return Ok(product);
        }

        // Get All Brands
        [HttpGet("brands")] // Get :: BaseUrl/api/Products/brands
        public async Task< ActionResult<BrandDto>> GetAllBrands()
        {
            var Brands = await _serviceManager.ProductService.GetAllBrandsAsync();
            return Ok(Brands);
        }

        // Get All Types
        [HttpGet("types")] // Get :: BaseUrl/api/Products/types
        public async Task< ActionResult<TypeDto>> GetAllTypes()
        {
            var Types = await _serviceManager.ProductService.GetAllTypesAsync();
            return Ok(Types);
        }

    }
}

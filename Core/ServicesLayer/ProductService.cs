using AutoMapper;
using DomainLayer.Contracts;
using DomainLayer.Models;
using ServiceAbstractionLayer;
using ServiceLayer.Specifications;
using Shared;
using Shared.DTOS;


namespace ServiceLayer
{
    public class ProductService(IUnitOfWork _unitOfWork, IMapper _mapper) : IProductService
    {
        public async Task<IEnumerable<BrandDto>> GetAllBrandsAsync()
        {
            var repo = _unitOfWork.GetRepository<ProductBrand, int>();
            var brands = await repo.GetAllAsync();

            var brandsDtos = _mapper.Map<IEnumerable<BrandDto>>(brands);

            return brandsDtos;

        }

        public async Task<IEnumerable<ProductDto>> GetAllProductAsync(int? brandId, int? typeId , ProductSortingOptions sortOption)
        {
            var spec = new ProductWithBrandAndTypeSpiecifications(brandId,typeId,sortOption); // include ProductType and ProductBrand

            var products = await _unitOfWork.GetRepository<Product, int>().GetAllAsync(spec);
            var productDtos = _mapper.Map<IEnumerable<ProductDto>>(products);

            return productDtos;

        }

        public async Task<IEnumerable<TypeDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typeDtos= _mapper.Map<IEnumerable<TypeDto>>(types);

            return typeDtos;
        }

        public async Task<ProductDto> GetProductByIdAsync(int id)
        {
            var spcef = new ProductWithBrandAndTypeSpiecifications(id);
            var repo = _unitOfWork.GetRepository<Product, int>();
            var product = await repo.GetByIdAsync(spcef);

            var productDto = _mapper.Map<ProductDto>(product);
            return productDto;

        }
    }
}

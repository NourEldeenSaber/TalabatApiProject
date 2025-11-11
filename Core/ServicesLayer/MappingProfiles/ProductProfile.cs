using AutoMapper;
using DomainLayer.Models;
using Shared.DTOS;

namespace ServiceLayer.MappingProfiles
{
    public class ProductProfile : Profile
    {
        public ProductProfile() {

            CreateMap<Product, ProductDto>()
                .ForMember(D => D.BrandName , options => options.MapFrom(src => src.ProductBrand.Name))
                .ForMember(D => D.TypeName , options => options.MapFrom(src => src.ProductType.Name));

            CreateMap<ProductType, TypeDto>();
            CreateMap<ProductBrand, BrandDto>();




        }
    }
}

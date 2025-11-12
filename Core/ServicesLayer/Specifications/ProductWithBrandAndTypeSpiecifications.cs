using DomainLayer.Models;
using Shared;

namespace ServiceLayer.Specifications
{
    internal class ProductWithBrandAndTypeSpiecifications : BaseSpecifications<Product,int>
    {
        //Get All Products
        public ProductWithBrandAndTypeSpiecifications(ProductQueryParams queryParams) 
            : base(p=> (!queryParams.brandId.HasValue || p.BrandId == queryParams.brandId) &&
            (!queryParams.typeId.HasValue || p.TypeId == queryParams.typeId))
        {
            // where(p=>p.brandId == brandId && p.typeId == typeId)
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (queryParams.sortOption) {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending(p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy(p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending(p => p.Price);
                    break;
                default:
                    break;
            }

        }

        //Get Product With Id
        public ProductWithBrandAndTypeSpiecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

    }
}

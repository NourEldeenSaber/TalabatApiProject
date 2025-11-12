using DomainLayer.Models;
using Shared;

namespace ServiceLayer.Specifications
{
    internal class ProductWithBrandAndTypeSpiecifications : BaseSpecifications<Product,int>
    {
        //Get All Products
        public ProductWithBrandAndTypeSpiecifications(int? brandId, int? typeId , ProductSortingOptions sortOption) 
            : base(p=> (!brandId.HasValue || p.BrandId == brandId) &&
            (! typeId.HasValue || p.TypeId == typeId))
        {
            // where(p=>p.brandId == brandId && p.typeId == typeId)
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);

            switch (sortOption) {
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

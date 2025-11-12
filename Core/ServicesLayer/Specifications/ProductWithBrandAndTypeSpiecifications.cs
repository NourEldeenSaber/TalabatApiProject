using DomainLayer.Models;

namespace ServiceLayer.Specifications
{
    internal class ProductWithBrandAndTypeSpiecifications : BaseSpecifications<Product,int>
    {
        //Get All Products
        public ProductWithBrandAndTypeSpiecifications(int? brandId, int? typeId) 
            : base(p=> (!brandId.HasValue || p.BrandId == brandId) &&
            (! typeId.HasValue || p.TypeId == typeId))
        {
            // where(p=>p.brandId == brandId && p.typeId == typeId)
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

        //Get Product With Id
        public ProductWithBrandAndTypeSpiecifications(int id) : base(p => p.Id == id)
        {
            AddInclude(p => p.ProductType);
            AddInclude(p => p.ProductBrand);
        }

    }
}

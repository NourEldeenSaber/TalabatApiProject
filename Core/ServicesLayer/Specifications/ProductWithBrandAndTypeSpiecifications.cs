using DomainLayer.Models;

namespace ServiceLayer.Specifications
{
    internal class ProductWithBrandAndTypeSpiecifications : BaseSpecifications<Product,int>
    {
        //Get All Products
        public ProductWithBrandAndTypeSpiecifications() : base(null!)
        {
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

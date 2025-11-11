using AutoMapper;
using DomainLayer.Contracts;
using ServiceAbstractionLayer;

namespace ServiceLayer
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper) : IServiceManager
    {
        private readonly Lazy<IProductService> _LazyProductSrvice =
            new Lazy<IProductService>(() => new ProductService(_unitOfWork,_mapper)) ;
        public IProductService ProductService =>_LazyProductSrvice.Value;
    }
}

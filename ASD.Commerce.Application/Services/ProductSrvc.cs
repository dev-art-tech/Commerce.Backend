using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Contracts.Services;
using ASD.Commerce.Domain.Entities;

namespace ASD.Commerce.Application.Services
{
    public class ProductSrvc : BaseSrvc<Product>, IProductSrvc
    {
        public ProductSrvc(IUnitOfWork<Product> unitOfWork) : base(unitOfWork) { }
        public async Task<IEnumerable<Product>> GetMostExpensiveProducts(int count)
        {
            return await _unitOfWork.Products.GetMostExpensiveProductsAsync(count);
        }
    }
}

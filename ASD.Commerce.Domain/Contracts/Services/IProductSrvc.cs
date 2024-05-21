using ASD.Commerce.Domain.Entities;

namespace ASD.Commerce.Domain.Contracts.Services
{
    public interface IProductSrvc : IBaseSrvc<Product>
    {
        Task<IEnumerable<Product>> GetMostExpensiveProducts(int count);
    }
}

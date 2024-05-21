using ASD.Commerce.Domain.Entities;

namespace ASD.Commerce.Domain.Contracts
{
    public interface IProductRepo : IRepository<Product>
    {
        public Task<IEnumerable<Product>> GetMostExpensiveProductsAsync(int count);
    }
}

using ASD.Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Commerce.Domain.Contracts
{
    public interface IUnitOfWork<T>
       // : IDisposable 
        where T : BaseEntity
    {
        ICategoryRepo Categories { get; }
        IProductRepo Products { get; }
        IRepository<T> Repositories { get; }
        Task<int> CompleteAsync();
    }
}

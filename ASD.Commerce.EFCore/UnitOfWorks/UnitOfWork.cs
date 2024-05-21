using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Entities;
using ASD.Commerce.EFCore.Repositories;

namespace ASD.Commerce.EFCore.UnitOfWorks
{
    public class UnitOfWork<T> : IUnitOfWork<T> where T : BaseEntity
    {
        private readonly ApplicationDbContext _context;
        //private bool _disposed = false;

        public IRepository<T> Repositories { get; private set; }
        public ICategoryRepo Categories { get; private set; }
        public IProductRepo Products { get; private set; }
        public UnitOfWork(ApplicationDbContext context)
        {
            _context = context;
            Repositories = new Repository<T>(_context);
            Categories = new CategoryRepo(_context);
            Products = new ProductRepo(_context);
        }

        public async Task<int> CompleteAsync()
        {
            return await _context.SaveChangesAsync();
        }

        //public void Dispose()
        //{
        //    Dispose(true);
        //    GC.SuppressFinalize(this);
        //}

       // ~UnitOfWork() { Dispose(false); }

        //protected virtual void Dispose(bool disposing)
        //{
        //    if (!_disposed)
        //        if (disposing)
        //            _context.Dispose();
        //    _disposed = true;
        //}
    }
}

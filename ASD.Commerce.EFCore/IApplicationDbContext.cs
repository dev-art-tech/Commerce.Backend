using ASD.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ASD.Commerce.EFCore
{
    public interface IApplicationDbContext 
    {
        DbSet<Category> Categories { get; set; }
        DbSet<Product> Products { get; set; }

        Task<int> SaveChangesAsync();
        DbSet<T> Set<T>() where T : class;
    }
}
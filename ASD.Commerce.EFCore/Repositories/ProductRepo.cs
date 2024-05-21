using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Commerce.EFCore.Repositories
{
    public class ProductRepo : Repository<Product>, IProductRepo
    {
        public ProductRepo(ApplicationDbContext context) : base(context) { }
        public async Task<IEnumerable<Product>> GetMostExpensiveProductsAsync(int count)
        {
            return await _context.Set<Product>().Where(p => p.Price.HasValue && p.Price.Value > 0).OrderByDescending(p => p.Price).Take(count).ToListAsync();
        }
    }
}

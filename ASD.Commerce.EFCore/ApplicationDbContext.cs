using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ASD.Commerce.Domain;
using ASD.Commerce.Domain.Entities;

namespace ASD.Commerce.EFCore
{
    public class ApplicationDbContext: DbContext
        //, IApplicationDbContext<T>
        //where T : BaseEntity
    {
        public ApplicationDbContext() { }
        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Product> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=CommerceContext;Integrated Security=True;Connect Timeout=3000;MultipleActiveResultSets=true;Trust Server Certificate=True;",
                b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName));
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<int> SaveChangesAsync()
        {
            return await base.SaveChangesAsync();
        }

        //public override DbSet<T> Set<T>() where T : class
        //{
        //    return base.Set<T>();
        //}
    }
}


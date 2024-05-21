using ASD.Commerce.Application.Services;
using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Contracts.Services;
using ASD.Commerce.EFCore.Repositories;
using ASD.Commerce.EFCore.UnitOfWorks;
using Microsoft.Extensions.DependencyInjection;

namespace ASD.Commerce.Application
{
    public static class ServiceDependencies
    {
        public static void Configure(IServiceCollection services) {
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<ICategoryRepo, CategoryRepo>();
            services.AddScoped<IProductRepo, ProductRepo>();

            services.AddScoped(typeof(IUnitOfWork<>), typeof(UnitOfWork<>));

            services.AddScoped(typeof(IBaseSrvc<>), typeof(BaseSrvc<>));
            services.AddScoped<ICategorySrvc, CategorySrvc>();
            services.AddScoped<IProductSrvc, ProductSrvc>();
        }
    }
}

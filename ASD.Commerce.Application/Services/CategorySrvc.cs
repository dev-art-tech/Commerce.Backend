using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Contracts.Services;
using ASD.Commerce.Domain.Entities;

namespace ASD.Commerce.Application.Services
{
    public class CategorySrvc : BaseSrvc<Category>, ICategorySrvc
    {
        public CategorySrvc(IUnitOfWork<Category> unitOfWork) : base(unitOfWork) 
        {
        }
    }
}

using ASD.Commerce.Domain.Contracts;
using ASD.Commerce.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASD.Commerce.EFCore.Repositories
{
    public class CategoryRepo : Repository<Category>,  ICategoryRepo
    {
        public CategoryRepo(ApplicationDbContext context) : base(context) { }
    }
}


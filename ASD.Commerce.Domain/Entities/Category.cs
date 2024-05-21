
namespace ASD.Commerce.Domain.Entities
{
    public class Category : BaseEntity
    {
        public virtual string? Name { get; set; }
        public virtual List<Product>? Products { get; set; }
       
    }
}

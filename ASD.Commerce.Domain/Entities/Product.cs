using System.ComponentModel.DataAnnotations.Schema;

namespace ASD.Commerce.Domain.Entities
{
    public class Product: BaseEntity
    {
        public virtual string? Name { get; set; }
        public virtual decimal? Price { get; set; }
        public virtual string? Description { get; set; }
        [ForeignKey("Category_Product_Id")]
        public virtual int? CategoryId { get; set; }
    }
}

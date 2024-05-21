using System.ComponentModel.DataAnnotations;

namespace ASD.Commerce.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public virtual int Id { get; set; }
        public virtual DateTime? CreatedOn { get; set; }
        public virtual DateTime? UpdatedOn { get; set; }
    }
}

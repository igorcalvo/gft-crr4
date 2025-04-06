using System.ComponentModel.DataAnnotations;

namespace CashFlow.Domain.Entities
{
    public class BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
    }
}

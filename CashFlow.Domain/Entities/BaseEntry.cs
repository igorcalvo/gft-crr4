namespace CashFlow.Domain.Entities
{
    public class BaseEntry : BaseEntity
    {
        public DateTime CreatedAt { get; set; }
        public DateTime LastUpdatedAt { get; set; }
    }
}

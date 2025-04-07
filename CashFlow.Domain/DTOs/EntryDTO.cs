using CashFlow.Domain.Enums;

namespace CashFlow.Domain.DTOs
{
    public class EntryDto
    {
        public decimal Amount { get; set; }
        public EntryTypeEnum Type { get; set; }
        public Guid CounterPartyId { get; set; }
    }
}

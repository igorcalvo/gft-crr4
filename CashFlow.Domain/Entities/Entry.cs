using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Entry : BaseEntry
    {
        public decimal Amount { get; set; }
        public EntryTypeEnum Type { get; set; }
    }
}

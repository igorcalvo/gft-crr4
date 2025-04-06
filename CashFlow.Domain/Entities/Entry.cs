using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CashFlow.Domain.Enums;

namespace CashFlow.Domain.Entities
{
    public class Entry : BaseEntry
    {
        [Required]
        public decimal Amount { get; set; }

        [Required]
        public EntryTypeEnum Type { get; set; }

        [ForeignKey("Counterparty")]
        public Guid CounterPartyId { get; set; }
        public Counterparty Counterparty { get; set; }
    }
}

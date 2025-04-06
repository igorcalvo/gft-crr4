namespace CashFlow.Domain.Entities
{
    public class Consolidation : BaseEntry
    {
        public decimal TotalCredit { get; set; }
        public decimal TotalDebit { get; set; }
        public decimal NetBalance => TotalCredit - TotalDebit;
    }
}

namespace CashFlow.Domain.Entities
{
    public class CounterParty : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public string Identifier { get; set; } //CPF/CNPJ (could be a class for validation)
    }
}

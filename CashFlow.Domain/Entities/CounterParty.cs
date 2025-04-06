using System.ComponentModel.DataAnnotations;

namespace CashFlow.Domain.Entities
{
    public class Counterparty : BaseEntity
    {
        [Required]
        public string Name { get; set; }

        public string Address { get; set; }

        [Required]
        public string Identifier { get; set; } //CPF/CNPJ (could be a class for additional validation)
    }
}

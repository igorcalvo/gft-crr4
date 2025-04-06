using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface ICounterpartyRepository : IRepository<Counterparty>
    {
        Task<Counterparty?> GetByIdentifierAsync(string identifier);
    }
}

using CashFlow.Domain.Entities;

namespace CashFlow.Core.Interfaces
{
    public interface ICounterpartyService
    {
        public Task DeleteAsync(Guid id);

        public Task AddAsync(Counterparty counterparty);

        public Task UpdateAsync(Counterparty counterparty);
    }
}

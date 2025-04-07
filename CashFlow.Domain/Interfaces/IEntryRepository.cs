using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface IEntryRepository : IRepository<Entry>
    {
        Task<IEnumerable<Entry>> GetByDateAsync(DateTime date);
        Task<IEnumerable<Entry>> GetByCounterpartyIdAsync(Guid CounterpartyId);
    }
}

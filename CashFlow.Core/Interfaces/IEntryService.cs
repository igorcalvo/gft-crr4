using CashFlow.Domain.Entities;

namespace CashFlow.Core.Interfaces
{
    public interface IEntryService
    {
        public Task DeleteAsync(Guid id);

        public Task AddAsync(Entry entry);

        public Task UpdateAsync(Entry entry);
    }
}

using CashFlow.Domain.DTOs;
using CashFlow.Domain.Entities;

namespace CashFlow.Core.Interfaces
{
    public interface IEntryService
    {
        public Task DeleteAsync(Guid id);

        public Task<Entry> AddAsync(EntryDto dto);

        public Task<Entry> UpdateAsync(EntryDto dto);
    }
}

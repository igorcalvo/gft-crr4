using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Interfaces
{
    public interface IConsolidationRepository : IRepository<Consolidation>
    {
        Task<Consolidation?> GetByDateAsync(DateTime date);
    }
}

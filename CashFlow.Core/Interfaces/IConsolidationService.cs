using CashFlow.Domain.Entities;

namespace CashFlow.Core.Interfaces
{
    public interface IConsolidationService
    {
       public Task<Consolidation> GetTodaysResult();

        public Task<Consolidation> GetResultFromDate(DateTime date);
    }
}

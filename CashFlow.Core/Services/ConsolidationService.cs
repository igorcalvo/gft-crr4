using CashFlow.Core.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Enums;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Core.Services
{
    public class ConsolidationService : IConsolidationService
    {
        private readonly IConsolidationRepository _consolidationRepository;
        private readonly IEntryRepository _entryRepository;

        public ConsolidationService(IConsolidationRepository consolidationRepository, IEntryRepository entryRepository)
        {
            _consolidationRepository = consolidationRepository;
            _entryRepository = entryRepository;
        }

        public async Task AddConsolidation()
        {
            var today = DateTime.Today;
            var entries = await _entryRepository.GetByDateAsync(today);

            var credit = entries.Where(e => e.Type == EntryTypeEnum.Credit).Sum(e => e.Amount);
            var debit = entries.Where(e => e.Type == EntryTypeEnum.Debit).Sum(e => e.Amount);

            Consolidation consolidation = new()
            {
                CreatedAt = DateTime.Now,
                TotalCredit = credit,
                TotalDebit = debit
            };

            // Adicionaria alguma logica de validacao antes de adicioná-la
            await _consolidationRepository.AddAsync(consolidation);
        }

        public Task<Consolidation?> GetResultFromDate(DateTime date)
        {
            var consolidation = _consolidationRepository.GetByDateAsync(date.Date);
            return consolidation;
        }

        public Task<Consolidation?> GetTodaysResult()
        {
            return GetResultFromDate(DateTime.Today);
        }

        public async Task UpdateConsolidation(Consolidation Consolidation)
        {
            // Também adicionaria alguma validação antes de atualizá-la
            await _ConsolidationRepository.UpdateAsync(Consolidation);
        }
    }
}


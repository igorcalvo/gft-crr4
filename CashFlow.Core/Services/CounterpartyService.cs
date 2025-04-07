using CashFlow.Core.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Core.Services
{
    public class CounterpartyService : ICounterpartyService
    {
        private readonly ICounterpartyRepository _counterpartyRepository;
        private readonly IEntryRepository _entryRepository;

        public CounterpartyService(ICounterpartyRepository counterpartyRepository, IEntryRepository entryRepository)
        {
            _counterpartyRepository = counterpartyRepository;
            _entryRepository = entryRepository;
        }

        public async Task AddAsync(Counterparty counterparty)
        {
            counterparty.CreatedAt = DateTime.Now;

            var existingConterparty = await _counterpartyRepository.GetByIdAsync(counterparty.Id);
            if (existingConterparty != null) throw new InvalidOperationException("Esse registro já existe");

            // Adicionaria alguma logica de validacao antes de adicioná-la
            await _counterpartyRepository.AddAsync(counterparty);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entries = await _entryRepository.GetByCounterpartyIdAsync(id);
            if (entries.Any()) throw new InvalidOperationException("Há registros associados a essa counterparty então não pode ser deletada");

            await _counterpartyRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Counterparty counterparty)
        {
            // Também adicionaria alguma validação antes de atualizá-la
            await _counterpartyRepository.UpdateAsync(counterparty);
        }
    }
}

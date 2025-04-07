using CashFlow.Core.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Core.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;

        public EntryService(IEntryRepository entryRepository)
        {
            _entryRepository = entryRepository;
        }

        public async Task AddAsync(Entry entry)
        {
            entry.CreatedAt = DateTime.Now;

            var existingEntry = _entryRepository.GetByIdAsync(entry.Id);
            if (existingEntry != null) throw new InvalidOperationException("Esse registro já existe");

            // Adicionaria alguma logica de validacao antes de adicioná-la
            await _entryRepository.AddAsync(entry);
        }

        public async Task DeleteAsync(Guid id)
        {
            var entry = await _entryRepository.GetByIdAsync(id);

            if (entry == null) return;

            if (entry?.CreatedAt <= DateTime.Today) throw new InvalidOperationException("Registros passados não podem ser deletados");
            //Caso contrario, alterariam o resultado consolidado

            await _entryRepository.DeleteAsync(id);
        }

        public async Task UpdateAsync(Entry entry)
        {
            // Também adicionaria alguma validação antes de atualizá-la
            await _entryRepository.UpdateAsync(entry);
        }
    }
}

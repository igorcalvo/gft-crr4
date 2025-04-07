using AutoMapper;
using CashFlow.Core.Interfaces;
using CashFlow.Domain.DTOs;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;

namespace CashFlow.Core.Services
{
    public class EntryService : IEntryService
    {
        private readonly IEntryRepository _entryRepository;
        private readonly ICounterpartyRepository _counterPartyRepository;
        private readonly IMapper _mapper;

        public EntryService(IEntryRepository entryRepository, ICounterpartyRepository counterPartyRepository, IMapper mapper)
        {
            _entryRepository = entryRepository;
            _counterPartyRepository = counterPartyRepository;
            _mapper = mapper;
        }

        public async Task<Entry> AddAsync(EntryDto dto)
        {
            var entry = _mapper.Map<Entry>(dto);
            entry.CreatedAt = DateTime.Now;

            if (entry.CounterPartyId == Guid.Empty) throw new ArgumentNullException("Forneça um ID para counterparty");
            var counterparty = await _counterPartyRepository.GetByIdAsync(entry.CounterPartyId);

            if (counterparty == null) throw new ArgumentOutOfRangeException("Forneça um ID válido para counterparty");
            entry.Counterparty = counterparty;

            var existingEntry = await _entryRepository.GetByIdAsync(entry.Id);
            if (existingEntry != null) throw new InvalidOperationException("Esse registro já existe");

            // Adicionaria alguma logica de validacao antes de adicioná-la
            await _entryRepository.AddAsync(entry);
            return entry;
        }

        public async Task DeleteAsync(Guid id)
        {
            var entry = await _entryRepository.GetByIdAsync(id);

            if (entry == null) return;

            if (entry?.CreatedAt <= DateTime.Today) throw new InvalidOperationException("Registros passados não podem ser deletados");
            //Caso contrario, alterariam o resultado consolidado

            await _entryRepository.DeleteAsync(id);
        }

        public async Task<Entry> UpdateAsync(EntryDto dto)
        {
            var entry = _mapper.Map<Entry>(dto);
            // Também adicionaria alguma validação antes de atualizá-la
            await _entryRepository.UpdateAsync(entry);
            return entry;
        }
    }
}

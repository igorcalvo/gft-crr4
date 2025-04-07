using CashFlow.Core.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers
{
    public class CounterpartyController : BaseController
    {
        private readonly ICounterpartyService _counterpartyService;
        private readonly ICounterpartyRepository _counterpartyRepository;

        public CounterpartyController(ICounterpartyService counterpartyService, ICounterpartyRepository counterpartyRepository)
        {
            _counterpartyService = counterpartyService;
            _counterpartyRepository = counterpartyRepository;
        }

        // Idealmente a classe de dominio nao seria exposta aqui, mas estou com tempo limitado.

        [HttpGet]
        [Route(nameof(GetAll))]
        public async Task<IActionResult> GetAll()
        {
            var counterparties = await _counterpartyRepository.GetAllAsync();
            return Ok(counterparties);
        }

        [HttpGet]
        [Route(nameof(GetByIdentifier))]
        public async Task<IActionResult> GetByIdentifier(string identifier)
        {
            var counterparty = await _counterpartyRepository.GetByIdentifierAsync(identifier);
            return Ok(counterparty);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _counterpartyService.DeleteAsync(id);
            return Ok();
        }

        // Idealmente nao utilizaria entidades de dominio aqui, mas sim DTOs
        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] Counterparty counterparty)
        {
            await _counterpartyService.UpdateAsync(counterparty);
            return Ok(counterparty.Id);
        }

        // Idealmente nao utilizaria entidades de dominio aqui, mas sim DTOs
        [HttpPost]
        [Route(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] Counterparty counterparty)
        {
            await _counterpartyService.AddAsync(counterparty);
            return Ok(counterparty.Id);
        }
    }
}

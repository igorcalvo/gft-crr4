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
        public async Task<IActionResult> GetAll()
        {
            var counterparties = await _counterpartyRepository.GetAllAsync();
            return Ok(counterparties);
        }

        [HttpGet]
        public async Task<IActionResult> GetByIdentifier(string identifier)
        {
            var counterparty = await _counterpartyRepository.GetByIdentifierAsync(identifier);
            return Ok(counterparty);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _counterpartyService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Counterparty counterparty)
        {
            await _counterpartyService.UpdateAsync(counterparty);
            return Ok(counterparty.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Counterparty counterparty)
        {
            await _counterpartyService.AddAsync(counterparty);
            return Ok(counterparty.Id);
        }
    }
}

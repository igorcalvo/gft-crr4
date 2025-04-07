using CashFlow.Core.Interfaces;
using CashFlow.Domain.DTOs;
using CashFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers
{
    public class EntryController : BaseController
    {
        private readonly IEntryService _entryService;
        private readonly IEntryRepository _entryRepository;

        public EntryController(IEntryService entryService, IEntryRepository entryRepository)
        {
            _entryService = entryService;
            _entryRepository = entryRepository;
        }

        [HttpGet]
        [Route(nameof(GetAllFromDate))]
        public async Task<IActionResult> GetAllFromDate(DateTime date)
        {
            var entries = await _entryRepository.GetByDateAsync(date);
            return Ok(entries);
        }

        [HttpDelete]
        [Route(nameof(Delete))]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _entryService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        [Route(nameof(Update))]
        public async Task<IActionResult> Update([FromBody] EntryDto dto)
        {
            var entry = await _entryService.UpdateAsync(dto);
            return Ok(entry.Id);
        }

        [HttpPost]
        [Route(nameof(Add))]
        public async Task<IActionResult> Add([FromBody] EntryDto dto)
        {
            var entry = await _entryService.AddAsync(dto);
            return Ok(entry.Id);
        }
    }
}

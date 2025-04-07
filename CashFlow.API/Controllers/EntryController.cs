using CashFlow.Core.Interfaces;
using CashFlow.Core.Services;
using CashFlow.Domain.Entities;
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
        public async Task<IActionResult> GetAllFromDate(DateTime date)
        {
            var entries = await _entryRepository.GetByDateAsync(date);
            return Ok(entries);
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            await _entryService.DeleteAsync(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] Entry entry)
        {
            await _entryService.UpdateAsync(entry);
            return Ok(entry.Id);
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] Entry entry)
        {
            await _entryService.AddAsync(entry);
            return Ok(entry.Id);
        }
    }
}

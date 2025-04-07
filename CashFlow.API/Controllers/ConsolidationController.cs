using CashFlow.Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CashFlow.API.Controllers
{
    public class ConsolidationController : BaseController
    {
        private readonly IConsolidationService _consolidationService;

        public ConsolidationController(IConsolidationService consolidationService)
        {
            _consolidationService = consolidationService;
        }

        [HttpGet]
        [Route(nameof(GetFromDate))]
        public async Task<IActionResult> GetFromDate(DateTime date)
        {
            var result = await _consolidationService.GetResultFromDate(date);
            return Ok(result);
        }

        [HttpGet]
        [Route(nameof(GetTodaysResult))]
        public async Task<IActionResult> GetTodaysResult()
        {
            var result = await _consolidationService.GetTodaysResult();
            return Ok(result);
        }
    }
}

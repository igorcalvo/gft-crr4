using CashFlow.Core.Interfaces;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
        public async Task<IActionResult> GetFromDate(DateTime date)
        {
            var result = await _consolidationService.GetResultFromDate(date);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetTodaysResult()
        {
            var result = await _consolidationService.GetTodaysResult();
            return Ok(result);
        }
    }
}

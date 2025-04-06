using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class ConsolidationRepository : BaseRepository<Consolidation>, IConsolidationRepository
    {
        private readonly CashFlowDbContext _context;

        public ConsolidationRepository(CashFlowDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Consolidation?> GetByDateAsync(DateTime date)
        {
            return await _context.Consolidations.FirstOrDefaultAsync(c => c.CreatedAt.Date == date.Date);
        }
    }
}

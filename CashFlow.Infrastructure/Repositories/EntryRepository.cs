using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class EntryRepository : BaseRepository<Entry>, IEntryRepository
    {
        private readonly CashFlowDbContext _context;

        public EntryRepository(CashFlowDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Entry>> GetByDateAsync(DateTime date)
        {
            return await _context.Entries
                .Where(e => e.CreatedAt.Date == date.Date)
                .ToListAsync();
        }
    }
}

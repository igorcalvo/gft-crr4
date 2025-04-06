using CashFlow.Domain.Entities;
using CashFlow.Domain.Interfaces;
using CashFlow.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Repositories
{
    public class CounterpartyRepository : BaseRepository<Counterparty>, ICounterpartyRepository
    {
        private readonly CashFlowDbContext _context;

        public CounterpartyRepository(CashFlowDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<Counterparty?> GetByIdentifierAsync(string identifier)
        {
            return await _context.Counterparties.FirstOrDefaultAsync(c => c.Identifier == identifier);
        }
    }
}

using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CashFlow.Infrastructure.Data
{
    public class CashFlowDbContext : DbContext
    {
        public DbSet<Entry> Entries { get; set; }
        public DbSet<Consolidation> Consolidations { get; set; }
        public DbSet<Counterparty> Counterparties { get; set; }

        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CashFlowDbContext).Assembly);
        }
    }
}

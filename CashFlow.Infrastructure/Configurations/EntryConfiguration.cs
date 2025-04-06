using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CashFlow.Infrastructure.Configurations
{
    public class EntryConfiguration : IEntityTypeConfiguration<Entry>
    {
        public void Configure(EntityTypeBuilder<Entry> builder)
        {
            builder.HasOne(e => e.Counterparty)
                   .WithMany()
                   .HasForeignKey(e => e.CounterPartyId)
                   .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

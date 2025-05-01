using HW.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW.Persistence.Configurations;

public class OrderConfiguration : IEntityTypeConfiguration<Order>
{
    public void Configure(EntityTypeBuilder<Order> builder)
    {
        builder.HasKey(o => o.Id);

        builder.HasMany(o => o.Candidates)
            .WithMany(a => a.OrdersAsCandidate)
            .UsingEntity<CandidateOrder>(
                l => l.HasOne<Account>().WithMany().HasForeignKey(e => e.CandidateId),
                r => r.HasOne<Order>().WithMany().HasForeignKey(e => e.OrderId));

        builder.HasOne(o => o.Executor)
            .WithMany(a => a.OrdersAsExecutor);

        builder.HasOne(o => o.Creator)
            .WithMany(a => a.OrdersAsCreator)
            .HasForeignKey(o => o.CreatorId);
    }
}

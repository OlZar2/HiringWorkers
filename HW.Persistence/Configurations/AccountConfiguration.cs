using HW.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW.Persistence.Configurations;

public class AccountConfiguration : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.ToTable("Accounts");
        builder.HasKey(a => a.Id);

        builder.OwnsOne(u => u.PhoneNumber, b =>
        {
            b.Property(pn => pn.Value).HasColumnName("PhoneNumber");
        });

        builder.OwnsOne(u => u.Email, b =>
        {
            b.Property(pn => pn.Value).HasColumnName("Email");
        });

        //builder.HasMany(a => a.OrdersAsCandidate)
        //    .WithMany(o => o.Candidates)
        //    .UsingEntity<AccountOrder>();
    }
}
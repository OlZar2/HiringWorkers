using HW.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW.Persistence.Configurations;

public class CompanyConfiguration : IEntityTypeConfiguration<Company>
{
    public void Configure(EntityTypeBuilder<Company> builder)
    {
        builder.ToTable("Companies");

        builder.OwnsOne(u => u.PhoneNumber, b =>
        {
            b.Property(pn => pn.Value).HasColumnName("PhoneNumber");
        });

        builder.OwnsOne(u => u.Email, b =>
        {
            b.Property(pn => pn.Value).HasColumnName("Email");
        });
    }
}

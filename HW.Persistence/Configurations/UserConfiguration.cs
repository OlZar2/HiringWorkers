using HW.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace HW.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Users");

        builder.OwnsOne(u => u.PhoneNumber, b =>
        {
            b.Property(pn => pn.Value).HasColumnName("PhoneNumber");
        });

        builder.OwnsOne(u => u.Email, b =>
        {
            b.Property(pn => pn.Value).HasColumnName("Email");
        });

        builder.OwnsOne(u => u.FullName, b =>
        {
            b.Property(fn => fn.FirstName).HasColumnName("FirstName");
            b.Property(fn => fn.SecondName).HasColumnName("SecondName");
            b.Property(fn => fn.Patronymic).HasColumnName("Patronymic");
        });
    }
}

using KargoTakip.Server.Domain.Kargolar;
using KargoTakip.Server.Domain.Kargolarim;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KargoTakip.Server.Infrastructure.Configurations;
internal sealed class KargoConfiguration : IEntityTypeConfiguration<Kargo>
{
    public void Configure(EntityTypeBuilder<Kargo> builder)
    {
        builder.OwnsOne(p => p.Gonderen, builder =>
        {
            builder.Property(p => p.FirstName).HasColumnType("varchar(50)"); //nvarchar(MAX)
            builder.Property(p => p.LastName).HasColumnType("varchar(50)");
            builder.Property(p => p.TCNumarasi).HasColumnType("varchar(11)");
            builder.Property(p => p.Email).HasColumnType("varchar(100)");
            builder.Property(p => p.PhoneNumber).HasColumnType("varchar(15)");
        });
        builder.OwnsOne(p => p.Alici, alici =>
        {
            alici.Property(p => p.FirstName).HasColumnType("varchar(50)");
            alici.Property(p => p.LastName).HasColumnType("varchar(50)");
            alici.Property(p => p.TCNumarasi).HasColumnType("varchar(11)");
            alici.Property(p => p.Email).HasColumnType("varchar(100)");
            alici.Property(p => p.PhoneNumber).HasColumnType("varchar(15)");
        });
        builder.OwnsOne(p => p.TeslimAdresi, adres =>
        {
            adres.Property(p => p.City).HasColumnType("varchar(500)");
            adres.Property(p => p.Town).HasColumnType("varchar(50)");
            adres.Property(p => p.Mahalle).HasColumnType("varchar(50)");
            adres.Property(p => p.Street).HasColumnType("varchar(50)");
            adres.Property(p => p.FullAddress).HasColumnType("varchar(200)");
        });
        builder.OwnsOne(p => p.KargoInformation, builder =>
        {
            builder
            .Property(p => p.KargoTipi)
            .HasConversion(
                tip => (int)tip,
                value => (KargoTipiEnum)value);
        });

        builder.HasQueryFilter(x => !x.IsDeleted);
    }
}

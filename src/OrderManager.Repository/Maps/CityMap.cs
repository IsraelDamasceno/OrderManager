using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class CityMap : BaseEntityMap<City>
    {
        public CityMap() : base("tb_city") { }

        public override void Configure(EntityTypeBuilder<City> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.UF).HasColumnName("uf").HasMaxLength(2).IsRequired();
            builder.Property(x => x.Active).HasColumnName("active").IsRequired();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class AddressMap : BaseEntityMap<Address>
    {
        public AddressMap() : base("tb_Address") { }

        public override void Configure(EntityTypeBuilder<Address> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Type).HasColumnName("type").IsRequired();
            builder.Property(x => x.PublicPlace).HasColumnName("public_place").HasMaxLength(50).IsRequired();
            builder.Property(x => x.District).HasColumnName("district").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Number).HasColumnName("number").HasMaxLength(10);
            builder.Property(x => x.Complement).HasColumnName("complement").HasMaxLength(50);
            builder.Property(x => x.PostalCode).HasColumnName("postal_code").HasMaxLength(8);

            builder.HasOne(x => x.Client).WithOne(x => x.Address).HasForeignKey<Client>(x => x.IdAddress);

            builder.Property(x => x.IdCity).HasColumnName("id_City").IsRequired();
            builder.HasOne(x => x.City).WithMany().HasForeignKey(x => x.IdCity);
        }
    }
}

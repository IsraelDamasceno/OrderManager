using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class PromotionProductMap : BaseEntityMap<PromotionProduct>
    {
        public PromotionProductMap() : base("tb_promotion_product") { }

        public override void Configure(EntityTypeBuilder<PromotionProduct> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Active).HasColumnName("active").IsRequired();

            builder.Property(x => x.IdImage).HasColumnName("id_image").IsRequired();
            builder.HasOne(x => x.Image).WithMany().HasForeignKey(x => x.IdImage);

            builder.Property(x => x.IdProduct).HasColumnName("id_product").IsRequired();
            builder.HasOne(x => x.Product).WithMany(x => x.Promotions).HasForeignKey(x => x.IdProduct);
        }
    }
}

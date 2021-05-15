using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class OrderProductMap : BaseEntityMap<OrderProduct>
    {
        public OrderProductMap() : base("tb_order_product") { }

        public override void Configure(EntityTypeBuilder<OrderProduct> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Quantity).HasColumnName("quantity").HasPrecision(2).IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").HasPrecision(17, 2).IsRequired();

            builder.Property(x => x.IdOrder).HasColumnName("id_order").IsRequired();
            builder.HasOne(x => x.Order).WithMany(x => x.Products).HasForeignKey(x => x.IdOrder);

            builder.Property(x => x.IdProduct).HasColumnName("id_product").IsRequired();
            builder.HasOne(x => x.Product).WithMany().HasForeignKey(x => x.IdProduct);
        }
    }
}

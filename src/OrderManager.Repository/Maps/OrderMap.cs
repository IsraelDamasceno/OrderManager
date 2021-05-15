using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class OrderMap : BaseEntityMap<Order>
    {
        public OrderMap() : base("tb_order") { }

        public override void Configure(EntityTypeBuilder<Order> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.OrderNumber).HasColumnName("OrderNumber").HasMaxLength(10).IsRequired();
            builder.Property(x => x.Amount).HasColumnName("amount").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Delivery).HasColumnName("Delivery");

            builder.Property(x => x.IdClient).HasColumnName("id_client").IsRequired();
            builder.HasOne(x => x.Client).WithMany(x => x.Orders).HasForeignKey(x => x.IdClient);
        }
    }
}

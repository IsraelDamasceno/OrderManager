using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace OrderManager.Repository.Maps
{
    public class ImageProductMap : BaseEntityMap<OrderManager.Domain.ImageProduct>
    {
        public ImageProductMap() : base("tb_image_product") { }

        public override void Configure(EntityTypeBuilder<OrderManager.Domain.ImageProduct> builder)
        {
            base.Configure(builder);
        }
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class ImageMap : BaseEntityMap<Image>
    {
        public ImageMap() : base("tb_image") { }

        public override void Configure(EntityTypeBuilder<Image> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(20).IsRequired();
            builder.Property(x => x.NameFile).HasColumnName("name_file").HasMaxLength(20).IsRequired();
            builder.Property(x => x.Main).HasColumnName("mai").IsRequired();
        }
    }
}

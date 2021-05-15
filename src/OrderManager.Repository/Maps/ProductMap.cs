using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class ProductMap : BaseEntityMap<Product>
    {
        public ProductMap() : base("tb_product") { }

        public override void Configure(EntityTypeBuilder<Product> builder)
        {
            base.Configure(builder);
            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Code).HasColumnName("code").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Description).HasColumnName("description").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Price).HasColumnName("price").HasPrecision(17, 2).IsRequired();
            builder.Property(x => x.Active).HasColumnName("active").IsRequired();

            builder.Property(x => x.IdCategory).HasColumnName("id_category").IsRequired();
            builder.HasOne(x => x.CategoryProduct).WithMany(x => x.Products).HasForeignKey(x => x.IdCategory);

            builder
                .HasMany(x => x.Images)
                .WithMany(x => x.Products)
                .UsingEntity<ImageProduct>(
                    x => x.HasOne(f => f.Image).WithMany().HasForeignKey(f => f.IdImage),
                    x => x.HasOne(f => f.Product).WithMany().HasForeignKey(f => f.IdProduct),
                    x =>
                    {
                        x.ToTable("tb_image_product");

                        x.HasKey(f => new { f.IdImage, f.IdProduct });

                        x.Property(x => x.IdImage).HasColumnName("id_image").IsRequired();
                        x.Property(x => x.IdProduct).HasColumnName("id_product").IsRequired();
                    }
                );
        }
    }
}

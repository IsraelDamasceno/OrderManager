using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class CategoriaProdutoMap : BaseEntityMap<CategoryProduct>
    {
        public CategoriaProdutoMap() : base("tb_category_product") { }

        public override void Configure(EntityTypeBuilder<CategoryProduct> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("name").HasMaxLength(50).IsRequired();
            builder.Property(x => x.Active).HasColumnName("active").IsRequired();
        }
    }
}

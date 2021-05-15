using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository.Maps
{
    public class ClienteMap : BaseEntityMap<Client>
    {
        public ClienteMap() : base("tb_client") { }

        public override void Configure(EntityTypeBuilder<Client> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name).HasColumnName("Name").HasMaxLength(100).IsRequired();
            builder.Property(x => x.CPF).HasColumnName("cpf").HasMaxLength(11).IsRequired();
            builder.Property(x => x.Active).HasColumnName("Active").IsRequired();

            builder.Property(x => x.IdAddress).HasColumnName("IdAddress").IsRequired();
        }
    }
}

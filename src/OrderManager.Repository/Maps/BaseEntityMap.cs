using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OrderManager.Domain;

namespace OrderManager.Repository
{
    public class BaseEntityMap<TDomain> : IEntityTypeConfiguration<TDomain> where TDomain : BaseEntity
    {
        private readonly string _tableName;

        public BaseEntityMap(string tableName = "")
        {
            _tableName = tableName;
        }

        public virtual void Configure(EntityTypeBuilder<TDomain> builder)
        {
            if (!string.IsNullOrEmpty(_tableName))
            {
                builder.ToTable(_tableName);
            }

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).HasColumnName("id").ValueGeneratedOnAdd();

            builder.Property(x => x.CreatedAt).HasColumnName("Created_At").IsRequired();
        }
    }
}

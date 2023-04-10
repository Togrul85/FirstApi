using FirstApi.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FirstApi.Data.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
        builder.Property(p=>p.Name).HasMaxLength(50).IsRequired(true);
            builder.Property(p=>p.SalePrice).IsRequired(true);
            //builder.Property(p=>p.CreatedDate).HasDefaultValue(DateTime.UtcNow);
            builder.Property(p => p.UpdateDate).HasDefaultValueSql("GetUtcDate()");
            builder.Property(p => p.CreatedDate).HasDefaultValue(DateTime.UtcNow);

        }
    }
}

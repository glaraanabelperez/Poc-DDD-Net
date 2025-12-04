
using Domain.Agregates;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Order.Persistence.Database.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
      
        public virtual DbSet<Product> Product { get; set; } = null!;

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name)
                   .HasMaxLength(200)
                   .IsRequired();

            builder.OwnsOne(p => p.Stock, stock =>
            {
                stock.Property(s => s.Quantity)
                     .HasColumnName("Stock")
                     .IsRequired();
            });
        }


    }
}


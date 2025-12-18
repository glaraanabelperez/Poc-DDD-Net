
using Infraestructure.DBContext.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infraestricture.Persistencia.DBContext
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
      
        public virtual DbSet<Product> Product { get; set; } = null!;

        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");

            builder.HasKey(x => x.id);

            //Completar campos/

        }


    }
}


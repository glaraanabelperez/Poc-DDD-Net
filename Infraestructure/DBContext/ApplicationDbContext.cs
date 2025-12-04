
using Domain.Agregates;
using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database.Configurations;

namespace Infraestricture.Persistencia.DBContext.AppDBContext
{
    public class ApplicationDbContext : DbContext
    {
        public virtual DbSet<Product> Product { get; set; } = null!;

        public ApplicationDbContext(DbContextOptions options) : base(options)
        {
        }
 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ModelConfig(modelBuilder);
        }
    
        protected void ModelConfig(ModelBuilder modelBuilder)
        {

            //modelBuilder.UseCollation("SQL_Latin1_General_CP1_CI_AS");
            modelBuilder.ApplyConfiguration(new ProductConfiguration());
          
        }
    }
}
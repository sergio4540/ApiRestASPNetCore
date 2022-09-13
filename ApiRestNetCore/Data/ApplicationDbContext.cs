

using ApiRestNetCore.Entidades;
using Microsoft.EntityFrameworkCore;

namespace ApiRestNetCore.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions options): base (options)
        {

        }

        protected override void  OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Product>(entity =>
            {

                // Definición de la clave foránea
                entity.HasOne(d => d.Categories)
                    .WithMany(p => p.Product)
                    .HasForeignKey(d => d.CategoryId);
            });


        }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Categories> Categories { get; set; }

    }
}

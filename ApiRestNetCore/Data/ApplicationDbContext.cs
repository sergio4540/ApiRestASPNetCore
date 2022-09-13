

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

            modelBuilder.Entity<Deliveries>(entity =>
            {

                // Definición de la clave foránea
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Deliveries)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<ShoppingOrder>(entity =>
            {

                // Definición de la clave foránea
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.ShoppingOrders)
                    .HasForeignKey(d => d.CustomerId);
            });

            modelBuilder.Entity<Payment>(entity =>
            {

                // Definición de la clave foránea
                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Payments)
                    .HasForeignKey(d => d.ClienteId);
            });

            modelBuilder.Entity<TransactionReports>(entity =>
            {

                // Definición de la clave foránea
                entity.HasOne(d => d.Product)
                    .WithMany(p => p.TransactionReports)
                    .HasForeignKey(d => d.ProductId)
                    .OnDelete(DeleteBehavior.ClientSetNull);

                entity.HasOne(d => d.ShoppingOrder)
                    .WithMany(p => p.TransactionReports)
                    .HasForeignKey(d => d.OrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull);
            });
        }


        public DbSet<Customer> Customer { get; set; }
        public DbSet<Product> Product { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<ShoppingOrder> ShoppingOrder { get; set; }
        public DbSet<Deliveries> Deliveries { get; set; }
        public DbSet<TransactionReports> TransactionReports { get; set; }
    }
}

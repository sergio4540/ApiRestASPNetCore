

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




        }


        public DbSet<Customer> Customer { get; set; }

    }
}

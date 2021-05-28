using Microsoft.EntityFrameworkCore;

namespace SecuringWebApiJwt.Entities
{
    public class ClientesDbContext: DbContext
    {
        public DbSet<Customer> Costumers { get; set; }
        public DbSet<Order> Orders { get; set; }

        public ClientesDbContext(DbContextOptions<ClientesDbContext> options) : base(options){


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder){

            modelBuilder.Entity<Customer>().ToTable("Customer");
            modelBuilder.Entity<Order>().ToTable("Order");
        }
    }
}
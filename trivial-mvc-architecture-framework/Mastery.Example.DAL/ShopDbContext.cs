using System.Data.Entity;
using Mastery.Example.DAL.Common.Models.Customer;
using Mastery.Example.DAL.Common.Models.Product;

namespace Mastery.Example.DAL
{
    public class ShopDbContext : DbContext
    {
        public ShopDbContext() : base("ShopStore") { }

        public DbSet<CustomerDbModel> Customers { get; set; }
        public DbSet<ProductDbModel> Products { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerDbModel>().ToTable("Customers");
            modelBuilder.Entity<ProductDbModel>().ToTable("Products");

            modelBuilder.Entity<CustomerDbModel>()
                .HasMany(c => c.Products)
                .WithMany(p => p.Customers)
                .Map(m =>
                {
                    m.ToTable("Orders");

                    m.MapLeftKey("CustomerId");
                    m.MapRightKey("ProductId");
                });
        }
    }
}

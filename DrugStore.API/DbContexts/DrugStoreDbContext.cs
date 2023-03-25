using DrugStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.API.DbContexts
{
    public class DrugStoreDbContext : DbContext
    {
        public DbSet<Products> Products { get; private set; } = null!;
        public DbSet<Invoices> Invoices { get; private set; } = null!;
        public DbSet<Receipts> Receipts { get; private set; } = null!;
        public DbSet<Insurances> Insurances { get; private set; } = null!;
        public DbSet<Categories> Categories { get; private set; } = null!;
        public DbSet<ProductsInvoice> ProductsInvoice { get; private set; } = null!;
        public DbSet<ProductsReceipt> ProductsReceipt { get; private set; } = null!;

        public DrugStoreDbContext(DbContextOptions<DrugStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>().HasData(new Categories(1, "Placeholder Category Name", "Placeholder Category Description"));
            modelBuilder.Entity<Insurances>().HasData(new Insurances(1, "Placeholder Insurance Name", "Placeholder Insurance Description"));
            modelBuilder.Entity<Suppliers>().HasData(new Suppliers(
                1,
                "Placeholder Supplier Name",
                "Placeholder Supplier Address",
                "0000000000",
                "PlaceholderSupplier@Email.com",
                00000,
                000000000,
                "Placeholder Supplier Description"));
            modelBuilder.Entity<Customers>().HasData(new Customers(
                1,
                "Placeholder Customer Name",
                "Placeholder Customer Address",
                "0000000000",
                "PlaceholderCustomer@Email.com",
                00000,
                000000000,
                "Placeholder Customer Description",
                1));
            modelBuilder.Entity<Products>().HasData(new Products(
                1,
                "Placeholder Product Name",
                10,
                20,
                "Placeholder Product Description",
                1));
            modelBuilder.Entity<Invoices>().HasData(new Invoices(
                1,
                DateTime.Now,
                "Placeholder Invoices Description",
                1));
            modelBuilder.Entity<Receipts>().HasData(new Receipts(
                1,
                DateTime.Now,
                "Placeholder Invoices Description",
                1));
        }
    }
}
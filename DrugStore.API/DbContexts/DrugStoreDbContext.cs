using DrugStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.API.DbContexts
{
    public class DrugStoreDbContext : DbContext
    {
        public DbSet<Supplier> Supplier { get; private set; } = null!;
        public DbSet<Customer> Customer { get; private set; } = null!;
        public DbSet<Product> Product { get; private set; } = null!;
        public DbSet<Invoice> Invoice { get; private set; } = null!;
        public DbSet<Receipt> Receipt { get; private set; } = null!;
        public DbSet<Insurance> Insurance { get; private set; } = null!;
        public DbSet<Category> Category { get; private set; } = null!;
        public DbSet<ProductInvoice> ProductInvoice { get; private set; } = null!;
        public DbSet<ProductReceipt> ProductReceipt { get; private set; } = null!;

        public DrugStoreDbContext(DbContextOptions<DrugStoreDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Category>().HasData(new Category(1, "Placeholder Category Name", "Placeholder Category Description"));
            modelBuilder.Entity<Insurance>().HasData(new Insurance(1, "Placeholder Insurance Name", "Placeholder Insurance Description"));
            modelBuilder.Entity<Supplier>().HasData(new Supplier(
                1,
                "Placeholder Supplier Name",
                "Placeholder Supplier Address",
                "0000000000",
                "PlaceholderSupplier@Email.com",
                "00000",
                "000000000",
                "Placeholder Supplier Description"));
            modelBuilder.Entity<Customer>().HasData(new Customer(
                1,
                "Placeholder Customer Name",
                "Placeholder Customer Address",
                "0000000000",
                "PlaceholderCustomer@Email.com",
                "00000",
                "000000000",
                "Placeholder Customer Description",
                1));
            modelBuilder.Entity<Product>().HasData(new Product(
                1,
                "Placeholder Product Name",
                10,
                20,
                "Placeholder Product Description",
                1));
            modelBuilder.Entity<Invoice>().HasData(new Invoice(
                1,
                DateTime.Now,
                "Placeholder Invoice Description",
                1));
            modelBuilder.Entity<Receipt>().HasData(new Receipt(
                1,
                DateTime.Now,
                "Placeholder Receipt Description",
                1));
            modelBuilder.Entity<ProductInvoice>().HasKey(pi => new { pi.InvoicesId, pi.ProductsId });
            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Invoices)
                .WithMany(i => i.ProductInvoice)
                .HasForeignKey(pi => pi.InvoicesId);
            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Products)
                .WithMany(p => p.ProductInvoice)
                .HasForeignKey(pi => pi.ProductsId);
            modelBuilder.Entity<ProductReceipt>().HasKey(pr => new { pr.ReceiptsId, pr.ProductsId });
            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Receipts)
                .WithMany(r => r.ProductReceipt)
                .HasForeignKey(pr => pr.ReceiptsId);
            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Products)
                .WithMany(p => p.ProductReceipt)
                .HasForeignKey(pr => pr.ProductsId);
            modelBuilder.Entity<ProductInvoice>().HasData(new ProductInvoice(100, "Placeholder ProductInvoice Description", 1, 1));
            modelBuilder.Entity<ProductReceipt>().HasData(new ProductReceipt(100, "Placeholder ProductReceipt Description", 1, 1));
        }
    }
}
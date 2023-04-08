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
            modelBuilder.Entity<ProductInvoice>().HasKey(pi => new { pi.InvoiceId, pi.ProductId });
            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Invoice)
                .WithMany(i => i.ProductInvoice)
                .HasForeignKey(pi => pi.InvoiceId);
            modelBuilder.Entity<ProductInvoice>()
                .HasOne(pi => pi.Product)
                .WithMany(p => p.ProductInvoice)
                .HasForeignKey(pi => pi.ProductId);
            modelBuilder.Entity<ProductReceipt>().HasKey(pr => new { pr.ReceiptId, pr.ProductId });
            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Receipt)
                .WithMany(r => r.ProductReceipt)
                .HasForeignKey(pr => pr.ReceiptId);
            modelBuilder.Entity<ProductReceipt>()
                .HasOne(pr => pr.Product)
                .WithMany(p => p.ProductReceipt)
                .HasForeignKey(pr => pr.ProductId);
            modelBuilder.Entity<ProductInvoice>().HasData(new ProductInvoice(100, "Placeholder ProductInvoice Description", 1, 1));
            modelBuilder.Entity<ProductReceipt>().HasData(new ProductReceipt(100, "Placeholder ProductReceipt Description", 1, 1));
        }
    }
}
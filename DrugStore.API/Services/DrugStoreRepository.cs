using DrugStore.API.DbContexts;
using DrugStore.API.Entities;
using Microsoft.EntityFrameworkCore;

namespace DrugStore.API.Services
{
    public class DrugStoreRepository : IDrugStoreRepository, IDisposable
    {
        private readonly DrugStoreDbContext _context;

        public DrugStoreRepository(DrugStoreDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
                _context?.Dispose();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public async Task<IEnumerable<Category?>> GetCategoriesAsync(int pageNumber, int pageSize)
        {
            return await _context.Category
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Category?> GetCategoryAsync(int categoryId)
        {
            return await _context.Category.FindAsync(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (category == null)
                throw new ArgumentNullException(nameof(category));

            await _context.Category.AddAsync(category);
        }

        public void UpdateCategory(Category category)
        {
            _context.Entry(category).State = EntityState.Modified;
        }

        public void DeleteCategory(Category category)
        {
            _context.Category.Remove(category);
        }

        public async Task<IEnumerable<Customer?>> GetCustomersAsync(int pageNumber, int pageSize)
        {
            return await _context.Customer
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Customer?> GetCustomerAsync(int customerId)
        {
            return await _context.Customer.FindAsync(customerId);
        }
        
        public async Task AddCustomerAsync(Customer customer)
        {
            if (customer == null)
                throw new ArgumentNullException(nameof(customer));

            await _context.Customer.AddAsync(customer);
        }

        public void UpdateCustomer(Customer customer)
        {
            _context.Entry(customer).State = EntityState.Modified;
        }

        public void DeleteCustomer(Customer customer)
        {
            _context.Customer.Remove(customer);
        }

        public async Task<IEnumerable<Insurance?>> GetInsurancesAsync(int pageNumber, int pageSize)
        {
            return await _context.Insurance
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Insurance?> GetInsuranceAsync(int insuranceId)
        {
            return await _context.Insurance.FindAsync(insuranceId);
        }

        public async Task AddInsuranceAsync(Insurance insurance)
        {
            if (insurance == null)
                throw new ArgumentNullException(nameof(insurance));

            await _context.Insurance.AddAsync(insurance);
        }

        public void UpdateInsurance(Insurance insurance)
        {
            _context.Entry(insurance).State = EntityState.Modified;
        }

        public void DeleteInsurance(Insurance insurance)
        {
            _context.Insurance.Remove(insurance);
        }

        public async Task<IEnumerable<Invoice?>> GetInvoicesAsync(int pageNumber, int pageSize)
        {
            return await _context.Invoice
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Invoice?> GetInvoiceAsync(int invoiceId)
        {
            return await _context.Invoice.FindAsync(invoiceId);
        }

        public async Task AddInvoiceAsync(Invoice invoice)
        {
            if (invoice == null)
                throw new ArgumentNullException(nameof(invoice));

            await _context.Invoice.AddAsync(invoice);
        }

        public void UpdateInvoice(Invoice invoice)
        {
            _context.Entry(invoice).State = EntityState.Modified;
        }

        public void DeleteInvoice(Invoice invoice)
        {
            _context.Invoice.Remove(invoice);
        }

        public async Task<IEnumerable<Product?>> GetProductsAsync(int pageNumber, int pageSize)
        {
            return await _context.Product
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Product?> GetProductAsync(int productId)
        {
            return await _context.Product.FindAsync(productId);
        }

        public async Task AddProductAsync(Product product)
        {
            if (product == null)
                throw new ArgumentNullException(nameof(product));

            await _context.Product.AddAsync(product);
        }

        public void UpdateProduct(Product product)
        {
            _context.Entry(product).State = EntityState.Modified;
        }

        public void DeleteProduct(Product product)
        {
            _context.Product.Remove(product);
        }

        public async Task<IEnumerable<ProductInvoice>> GetProductInvoicesAsync(int pageNumber, int pageSize)
        {
            return await _context.ProductInvoice
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ProductInvoice?> GetProductInvoiceAsync(int invoiceId, int productId)
        {
            return await _context.ProductInvoice
                .Where(pi => pi.InvoiceId == invoiceId && pi.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task AddProductInvoiceAsync(ProductInvoice productInvoice)
        {
            if (productInvoice == null)
                throw new ArgumentNullException(nameof(productInvoice));

            await _context.ProductInvoice.AddAsync(productInvoice);
        }

        public void UpdateProductInvoice(ProductInvoice productInvoice)
        {
            _context.Entry(productInvoice).State = EntityState.Modified;
        }

        public void DeleteProductInvoice(ProductInvoice productInvoice)
        {
            _context.ProductInvoice.Remove(productInvoice);
        }

        public async Task<IEnumerable<ProductReceipt?>> GetProductReceiptsAsync(int pageNumber, int pageSize)
        {
            return await _context.ProductReceipt
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<ProductReceipt?> GetProductReceiptAsync(int receiptId, int productId)
        {
            return await _context.ProductReceipt
                .Where(pr => pr.ReceiptId == receiptId && pr.ProductId == productId)
                .FirstOrDefaultAsync();
        }

        public async Task AddProductReceiptAsync(ProductReceipt productReceipt)
        {
            if (productReceipt == null)
                throw new ArgumentNullException(nameof(productReceipt));

            await _context.ProductReceipt.AddAsync(productReceipt);
        }

        public void UpdateProductReceipt(ProductReceipt productReceipt)
        {
            _context.Entry(productReceipt).State = EntityState.Modified;
        }

        public void DeleteProductReceipt(ProductReceipt productReceipt)
        {
            _context.ProductReceipt.Remove(productReceipt);
        }

        public async Task<IEnumerable<Receipt?>> GetReceiptsAsync(int pageNumber, int pageSize)
        {
            return await _context.Receipt
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Receipt?> GetReceiptAsync(int receiptId)
        {
            return await _context.Receipt.FindAsync(receiptId);
        }

        public async Task AddReceiptAsync(Receipt receipt)
        {
            if (receipt == null)
                throw new ArgumentNullException(nameof(receipt));

            await _context.Receipt.AddAsync(receipt);
        }

        public void UpdateReceipt(Receipt receipt)
        {
            _context.Entry(receipt).State = EntityState.Modified;
        }

        public void DeleteReceipt(Receipt receipt)
        {
            _context.Receipt.Remove(receipt);
        }

        public async Task<IEnumerable<Supplier?>> GetSuppliersAsync(int pageNumber, int pageSize)
        {
            return await _context.Supplier
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Supplier?> GetSupplierAsync(int supplierId)
        {
            return await _context.Supplier.FindAsync(supplierId);
        }

        public async Task AddSupplierAsync(Supplier supplier)
        {
            if (supplier == null)
                throw new ArgumentNullException(nameof(supplier));

            await _context.Supplier.AddAsync(supplier);
        }

        public void UpdateSupplier(Supplier supplier)
        {
            _context.Entry(supplier).State = EntityState.Modified;
        }

        public void DeleteSupplier(Supplier supplier)
        {
            _context.Supplier.Remove(supplier);
        }
    }
}
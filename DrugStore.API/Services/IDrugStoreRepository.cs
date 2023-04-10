using DrugStore.API.Entities;

namespace DrugStore.API.Services
{
    public interface IDrugStoreRepository
    {
        Task<bool> SaveChangesAsync();
        Task<IEnumerable<Category?>> GetCategoriesAsync(int pageNumber, int pageSize);
        Task<Category?> GetCategoryAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Task<IEnumerable<Customer?>> GetCustomersAsync(int pageNumber, int pageSize);
        Task<Customer?> GetCustomerAsync(int customerId);
        Task AddCustomerAsync(Customer customer);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(Customer customer);
        Task<IEnumerable<Insurance?>> GetInsurancesAsync(int pageNumber, int pageSize);
        Task<Insurance?> GetInsuranceAsync(int insuranceId);
        Task AddInsuranceAsync(Insurance insurance);
        void UpdateInsurance(Insurance insurance);
        void DeleteInsurance(Insurance insurance);
        Task<IEnumerable<Invoice?>> GetInvoicesAsync(int pageNumber, int pageSize);
        Task<Invoice?> GetInvoiceAsync(int invoiceId);
        Task AddInvoiceAsync(Invoice invoice);
        void UpdateInvoice(Invoice invoice);
        void DeleteInvoice(Invoice invoice);
        Task<IEnumerable<Product?>> GetProductsAsync(int pageNumber, int pageSize);
        Task<Product?> GetProductAsync(int productId);
        Task AddProductAsync(Product product);
        void UpdateProduct(Product product);
        void DeleteProduct(Product product);
        Task<IEnumerable<ProductInvoice>> GetProductInvoicesAsync(int pageNumber, int pageSize);
        Task<ProductInvoice?> GetProductInvoiceAsync(int invoiceId, int productId);
        Task AddProductInvoiceAsync(ProductInvoice productInvoice);
        void UpdateProductInvoice(ProductInvoice productInvoice);
        void DeleteProductInvoice(ProductInvoice productInvoice);
        Task<IEnumerable<ProductReceipt?>> GetProductReceiptsAsync(int pageNumber, int pageSize);
        Task<ProductReceipt?> GetProductReceiptAsync(int receiptId, int productId);
        Task AddProductReceiptAsync(ProductReceipt productReceipt);
        void UpdateProductReceipt(ProductReceipt productReceipt);
        void DeleteProductReceipt(ProductReceipt productReceipt);
        Task<IEnumerable<Receipt?>> GetReceiptsAsync(int pageNumber, int pageSize);
        Task<Receipt?> GetReceiptAsync(int receiptId);
        Task AddReceiptAsync(Receipt receipt);
        void UpdateReceipt(Receipt receipt);
        void DeleteReceipt(Receipt receipt);
        Task<IEnumerable<Supplier?>> GetSuppliersAsync(int pageNumber, int pageSize);
        Task<Supplier?> GetSupplierAsync(int supplierId);
        Task AddSupplierAsync(Supplier supplier);
        void UpdateSupplier(Supplier supplier);
        void DeleteSupplier(Supplier supplier);
    }
}
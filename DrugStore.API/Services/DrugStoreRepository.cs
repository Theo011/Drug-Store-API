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

        public async Task<IEnumerable<Category>> GetCategoriesAsync(int pageNumber, int pageSize)
        {
            return await _context.Category
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Category> GetCategoryAsync(int categoryId)
        {
            return await _context.Category.FindAsync(categoryId);
        }

        public async Task AddCategoryAsync(Category category)
        {
            if (category == null)
            {
                throw new ArgumentNullException(nameof(category));
            }

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

        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync() > 0);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {
                _context?.Dispose();
            }
        }
    }
}
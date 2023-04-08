using DrugStore.API.Entities;

namespace DrugStore.API.Services
{
    public interface IDrugStoreRepository
    {
        Task<IEnumerable<Category>> GetCategoriesAsync(int pageNumber, int pageSize);
        Task<Category> GetCategoryAsync(int categoryId);
        Task AddCategoryAsync(Category category);
        void UpdateCategory(Category category);
        void DeleteCategory(Category category);
        Task<bool> SaveChangesAsync();
    }
}
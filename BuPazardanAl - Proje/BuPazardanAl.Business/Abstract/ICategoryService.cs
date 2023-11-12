using BuPazardanAl.DataAccess.Abstract;
using BuPazardanAl.Entities.Concrete;
namespace BuPazardanAl.Business.Abstract
{
    public interface ICategoryService
    {
        public ICategoryDal _categoryDal { get; set; }

        Task<Category> GetCategoryAsync(int id) => _categoryDal.GetAsync(x => x.Id == id);

        async Task<List<Category>> GetCategoriesAllAsync() => (await _categoryDal.GetAllAsync()).OrderBy(x=>x.Name).ToList();

        async Task<bool> UpdateCategoryAsync(Category category) => await _categoryDal.UpdateAsync(category) > 0;

        async Task<bool> AddCategoryAsync(Category category) => await _categoryDal.AddAsync(category) > 0;

        async Task<bool> DeleteCategoryAsync(int categoryId) => await _categoryDal.RemoveAsync(await GetCategoryAsync(categoryId)) > 0;
    }
}

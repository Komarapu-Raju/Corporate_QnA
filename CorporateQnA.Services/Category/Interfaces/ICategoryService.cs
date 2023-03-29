using CorporateQnA.Core.Models.Categories;

namespace CorporateQnA.Services.Interfaces
{
    public interface ICategoryService
    {
        public void AddCategory(Category newCategory);

        public IEnumerable<Category> GetCategories();
    }
}

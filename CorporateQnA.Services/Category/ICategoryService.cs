using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;

namespace CorporateQnA.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryListItem> GetAllCategories();

        void AddCategory(Category newCategory);
    }
}

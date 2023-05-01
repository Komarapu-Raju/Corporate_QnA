using CorporateQnA.Data.Models.Category;
using CorporateQnA.Data.Models.Category.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface ICategoryService
    {
        public IEnumerable<CategoryDetailsView> GetAllCategories();

        public void AddCategory(Category newCategory);
    }
}

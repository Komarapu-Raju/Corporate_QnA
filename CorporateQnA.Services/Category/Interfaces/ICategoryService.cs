using CorporateQnA.Data.Models.Category;
using CorporateQnA.Data.Models.Category.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface ICategoryService
    {
        public long AddCategory(Category newCategory);

        public IEnumerable<CategoryDetailsView> GetCategories();
    }
}

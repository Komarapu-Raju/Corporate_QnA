using CorporateQnA.Data.Models.Category;
using CorporateQnA.Data.Models.Category.Views;
using CorporateQnA.Infrastructure.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper.Contrib.Extensions;
using System.Data;

namespace CorporateQnA.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly IDbConnection _db;

        public CategoryService(ApplicationDbContext db)
        {
            _db = db.GetConnection();
        }

        public long AddCategory(Category newCategory)
        {
            return _db.Insert(newCategory);
        }

        public IEnumerable<CategoryDetailsView> GetAllCategories()
        {
            return _db.GetAll<CategoryDetailsView>();
        }
    }
}

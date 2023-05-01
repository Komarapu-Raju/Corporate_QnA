using CorporateQnA.Data.Models.Category;
using CorporateQnA.Data.Models.Category.Views;
using CorporateQnA.DbContext;
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
            this._db = db.GetConnection();
        }

        public IEnumerable<CategoryDetailsView> GetAllCategories()
        {
            return this._db.GetAll<CategoryDetailsView>();
        }

        public void AddCategory(Category newCategory)
        {
            this._db.Insert(newCategory);
        }
    }
}

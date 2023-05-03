using AutoMapper;
using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;
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
        private readonly IMapper _mapper;

        public CategoryService(ApplicationDbContext db, IMapper mapper)
        {
            this._db = db.GetConnection();
            this._mapper = mapper;
        }

        public IEnumerable<CategoryListItem> GetAllCategories()
        {
            var categoryList = this._db.GetAll<CategoryDetailsView>();
            return this._mapper.Map<IEnumerable<CategoryListItem>>(categoryList);
        }

        public void AddCategory(Category newCategory)
        {
            var category = this._mapper.Map<CorporateQnA.Data.Models.Category.Category>(newCategory);
            this._db.Insert(category);
        }
    }
}

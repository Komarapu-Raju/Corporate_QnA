using AutoMapper;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.Category.Views;
using CorporateQnA.DbContext;
using CorporateQnA.Services.Interfaces;
using Dapper;
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

        public CategoryListItem AddCategory(Category newCategory)
        {
            var category = this._mapper.Map<CorporateQnA.Data.Models.Category.Category>(newCategory);
            var query = "insert into Category (title, description) output inserted.id values (@title, @description)";
            var newlyAddedCategoryId = this._db.ExecuteScalar<Guid>(query, new { title = category.Title, description = category.Description });
            return this.GetCategoryById(newlyAddedCategoryId);
        }

        public CategoryListItem GetCategoryById(Guid id)
        {
            var category = this._db.QuerySingleOrDefault<CategoryDetailsView>("Select * from CategoryDetails Where Id = @categoryId", new { categoryId = id });
            return this._mapper.Map<CategoryListItem>(category);
        }
    }
}

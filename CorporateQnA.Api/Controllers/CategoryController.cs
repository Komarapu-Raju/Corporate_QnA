using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        public CategoryController(ICategoryService categoryServices)
        {
            this._categoryServices = categoryServices;
        }

        [HttpPost]
        public CategoryListItem AddCategory(Category newCategory)
        {
            return this._categoryServices.AddCategory(newCategory);
        }

        [HttpGet("all")]
        public IEnumerable<CategoryListItem> GetCategoryList()
        {
            return this._categoryServices.GetAllCategories();
        }
    }
}

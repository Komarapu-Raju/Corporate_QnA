using AutoMapper;
using CorporateQnA.Core.Models.Categories;
using CorporateQnA.Core.Models.Categories.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryServices;

        private readonly IMapper _mapper;

        public CategoryController(ICategoryService categoryServices, IMapper mapper)
        {
            this._categoryServices = categoryServices;
            this._mapper = mapper;
        }

        [HttpGet("all")]
        public IEnumerable<CategoryListItem> GetCategoryList()
        {
            var categoryList = this._categoryServices.GetAllCategories();
            return this._mapper.Map<IEnumerable<CategoryListItem>>(categoryList);
        }

        [HttpPost]
        public long AddCategory(Category newCategory)
        {
            var category = this._mapper.Map<CorporateQnA.Data.Models.Category.Category>(newCategory);
            return this._categoryServices.AddCategory(category);
        }
    }
}

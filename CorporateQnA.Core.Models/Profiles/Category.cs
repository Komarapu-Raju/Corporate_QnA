using AutoMapper;
using CorporateQnA.Core.Models.Categories.ViewModels;
using CorporateQnA.Data.Models.Category.Views;

namespace CorporateQnA.Core.Models.Profiles
{
    public class Category : Profile
    {
        public Category()
        {
            CreateMap<CorporateQnA.Core.Models.Categories.Category, CorporateQnA.Data.Models.Category.Category>().ReverseMap();
            CreateMap<CategoryDetailsView, CategoryListItem>().ReverseMap();
        }
    }
}

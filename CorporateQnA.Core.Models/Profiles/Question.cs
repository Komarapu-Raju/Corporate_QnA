using AutoMapper;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Data.Models.Question.Views;

namespace CorporateQnA.Core.Models.Profiles
{
    public class Question : Profile
    {
        public Question()
        {
            CreateMap<CorporateQnA.Core.Models.Questions.Question, CorporateQnA.Data.Models.Question.Question>().ReverseMap();

            CreateMap<QuestionDetailsView, QuestionListItem>();
        }
    }
}

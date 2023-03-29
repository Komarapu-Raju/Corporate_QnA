using AutoMapper;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Data.Models.Answer.Views;

namespace CorporateQnA.Core.Models.Profiles
{
    public class Answer : Profile
    {
        public Answer()
        {
            CreateMap<CorporateQnA.Data.Models.Answer.Answer,CorporateQnA.Core.Models.Answers.Answer>().ReverseMap();

            CreateMap<AnswerListItem, AnswerDetailsView>().ReverseMap();
        }
    }
}

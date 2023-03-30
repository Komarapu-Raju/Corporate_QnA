using AutoMapper;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionServices;
        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionServices,IMapper mapper)
        {
            this._questionServices = questionServices;
            this._mapper = mapper;
        }

        [HttpGet("{id}")]
        public QuestionListItem GetQuestionById(Guid id)
        {
            var question = this._questionServices.GetQuestionById(id);
            return this._mapper.Map<QuestionListItem>(question);
        }

        [HttpGet("all")]
        public IEnumerable<QuestionListItem> GetAllQuestions()
        {
            var questions = this._questionServices.GetQuestionList();
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpPost]
        public long AddQuestion(Question newQuestion)
        {
            var question = this._mapper.Map<CorporateQnA.Data.Models.Question.Question>(newQuestion);
            return this._questionServices.AddQuestion(question);
        }
    }
}

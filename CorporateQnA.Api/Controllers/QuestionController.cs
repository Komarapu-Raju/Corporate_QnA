using AutoMapper;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class QuestionController : ControllerBase
    {
        private readonly IQuestionService _questionServices;

        private readonly IMapper _mapper;

        public QuestionController(IQuestionService questionServices, IMapper mapper)
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
            var questions = this._questionServices.GetAllQuestions();
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpGet("askedBy/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployeeId(Guid employeeId)
        {
            var questions = this._questionServices.GetQuestionsAskedByEmployee(employeeId);
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpGet("answeredBy/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployeeId(Guid employeeId)
        {
            var questions = this._questionServices.GetQuestionsAnsweredByEmployee(employeeId);
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpPost]
        public void AddQuestion(Question newQuestion)
        {
            var question = this._mapper.Map<CorporateQnA.Data.Models.Question.Question>(newQuestion);
            this._questionServices.AddQuestion(question);
        }

        [HttpPut]
        public void AddQuestionActivity(Guid questionId, Guid employeeId, short voteStatus)
        {
            var questionActivity = new EmployeeQuestionActivity();
            questionActivity.QuestionId = questionId;
            questionActivity.EmployeeId = employeeId;
            questionActivity.VoteStatus = voteStatus;
            this._questionServices.AddQuestionActivity(questionActivity);
        }
    }
}

using AutoMapper;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
using CorporateQnA.Data.Models.EmployeeActivities;
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
            var questions = this._questionServices.GetAllQuestion();
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpGet("{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployee(Guid employeeId)
        {
            var questions = this._questionServices.GetQuestionsAskedByEmployee(employeeId);
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpGet("answered/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployee(Guid employeeId)
        {
            var questions = this._questionServices.GetQuestionsAnsweredByEmployee(employeeId);
            return this._mapper.Map<IEnumerable<QuestionListItem>>(questions);
        }

        [HttpPost]
        public long AddQuestion(Question newQuestion)
        {
            var question = this._mapper.Map<CorporateQnA.Data.Models.Question.Question>(newQuestion);
            return this._questionServices.AddQuestion(question);
        }

        [HttpPut]
        public void AddQuestionActivity(Guid questionId, Guid employeeId)
        {
            var questionActivity = new EmployeeQuestionActivity();
            questionActivity.QuestionId = questionId;
            questionActivity.EmployeeId = employeeId;
            this._questionServices.AddQuestionActivity(questionActivity);
        }

        [HttpPut("vote")]
        public void VoteQuestion(Guid questionId, Guid employeeId, short voteStatus)
        {
            var questionActivity = new EmployeeQuestionActivity();
            questionActivity.QuestionId = questionId;
            questionActivity.EmployeeId = employeeId;
            questionActivity.VoteStatus = voteStatus;
            this._questionServices.VoteQuestion(questionActivity);
        }
    }
}

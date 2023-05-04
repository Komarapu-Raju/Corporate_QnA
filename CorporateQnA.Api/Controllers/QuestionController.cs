using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Core.Models.Questions;
using CorporateQnA.Core.Models.Questions.ViewModels;
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

        public QuestionController(IQuestionService questionServices)
        {
            this._questionServices = questionServices;
        }

        [HttpPost]
        public Guid AddQuestion(Question newQuestion)
        {
            return this._questionServices.AddQuestion(newQuestion);
        }

        [HttpGet("all")]
        public IEnumerable<QuestionListItem> GetAllQuestions()
        {
            return this._questionServices.GetAllQuestions();
        }

        [HttpGet("{id}")]
        public QuestionListItem GetQuestionById(Guid id)
        {
            return this._questionServices.GetQuestionById(id);
        }

        [HttpGet("asked/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployeeId(Guid employeeId)
        {
            return this._questionServices.GetQuestionsAskedByEmployee(employeeId);
        }

        [HttpGet("answered/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployeeId(Guid employeeId)
        {
            return this._questionServices.GetQuestionsAnsweredByEmployee(employeeId);
        }

        [HttpPut("addactivity")]
        public long AddQuestionActivity(Guid questionId)
        {
            return this._questionServices.AddQuestionActivity(questionId);
        }

        [HttpPut("vote")]
        public void VoteQuestion(Guid questionId, Vote voteStatus)
        {
            this._questionServices.VoteQuestion(questionId, voteStatus);
        }
    }
}

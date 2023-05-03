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
        public void AddQuestion(Question newQuestion)
        {
            this._questionServices.AddQuestion(newQuestion);
        }

        [HttpGet("all")]
        public IEnumerable<QuestionListItem> GetAllQuestions(Guid currentEmployeeId)
        {
            return this._questionServices.GetAllQuestions(currentEmployeeId);
        }

        [HttpGet("{id}")]
        public QuestionListItem GetQuestionById(Guid id, Guid currentEmployeeId)
        {
            return this._questionServices.GetQuestionById(id, currentEmployeeId);
        }

        [HttpGet("asked/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAskedByEmployeeId(Guid employeeId, Guid currentEmployeeId)
        {
            return this._questionServices.GetQuestionsAskedByEmployee(employeeId, currentEmployeeId);
        }

        [HttpGet("answered/{employeeId}")]
        public IEnumerable<QuestionListItem> GetQuestionsAnsweredByEmployeeId(Guid employeeId, Guid currentEmployeeId)
        {
            return this._questionServices.GetQuestionsAnsweredByEmployee(employeeId, currentEmployeeId);
        }

        [HttpPut("addactivity")]
        public long AddQuestionActivity(Guid questionId, Guid employeeId)
        {
            return this._questionServices.AddQuestionActivity(questionId, employeeId);
        }

        [HttpPut("vote")]
        public void VoteQuestion(Guid questionId, Guid employeeId, Vote voteStatus)
        {
            this._questionServices.VoteQuestion(questionId, employeeId, voteStatus);
        }
    }
}

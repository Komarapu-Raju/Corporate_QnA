using AutoMapper;
using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Data.Models.EmployeeActivities;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerServices;

        private readonly IMapper _mapper;

        public AnswerController(IAnswerService answerServices, IMapper mapper)
        {
            this._answerServices = answerServices;
            this._mapper = mapper;
        }

        [HttpGet("all/{questionId}")]
        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId)
        {
            var answers = this._answerServices.GetAnswersByQuestionId(questionId);
            return this._mapper.Map<IEnumerable<AnswerListItem>>(answers);
        }

        [HttpPost]
        public long AddAnswer(Answer newAnswer)
        {
            var answer = this._mapper.Map<CorporateQnA.Data.Models.Answer.Answer>(newAnswer);
            return this._answerServices.AddAnswer(answer);
        }

        [HttpPut]
        public void VoteAnswer(EmployeeAnswerActivity newActivity)
        {
            this._answerServices.VoteAnswer(newActivity);
        }
    }
}

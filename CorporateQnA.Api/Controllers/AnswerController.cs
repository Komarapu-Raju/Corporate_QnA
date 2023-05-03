﻿using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Enum;
using CorporateQnA.Services.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CorporateQnA.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]/")]
    [Authorize(AuthenticationSchemes = "Bearer")]
    public class AnswerController : ControllerBase
    {
        private readonly IAnswerService _answerServices;

        public AnswerController(IAnswerService answerServices)
        {
            this._answerServices = answerServices;
        }

        [HttpPost]
        public void AddAnswer(Answer newAnswer)
        {
            this._answerServices.AddAnswer(newAnswer);
        }

        [HttpGet("all/{questionId}")]
        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId, Guid currentEmployeeId)
        {
            return this._answerServices.GetAnswersByQuestionId(questionId, currentEmployeeId); ;
        }

        [HttpPut("vote")]
        public void VoteAnswer(Guid answerId, Guid employeeId, Vote voteStatus)
        {
            this._answerServices.VoteAnswer(answerId, employeeId, voteStatus);
        }

        [HttpPut("updatebestsolution")]
        public void UpdateBestSolution(Guid answerId)
        {
            this._answerServices.UpdateBestSolution(answerId);
        }
    }
}


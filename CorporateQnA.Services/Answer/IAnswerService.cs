﻿using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Enum;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId, Guid currentEmployeeId);

        IEnumerable<AnswerListItem> GetAnswersByEmployeeId(Guid employeeId, Guid currentEmployeeId);

        void AddAnswer(Answer answer);

        void VoteAnswer(Guid answerId, Guid employeeId, Vote voteStatus);

        void UpdateBestSolution(Guid answerId);
    }
}

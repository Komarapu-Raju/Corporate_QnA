﻿using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.EmployeeActivities;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        public long AddAnswer(Answer answer);

        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(Guid QuestionId);

        public IEnumerable<AnswerDetailsView> GetAnswersByEmployeeId(Guid employeeId);

        public void VoteAnswer(EmployeeAnswerActivity answerActivity);

        public void BestSolution(Guid answerId);
    }
}
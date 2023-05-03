using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Data.Models.Answer.Views;
using CorporateQnA.Data.Models.EmployeeActivities;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(Guid questionId,Guid currentEmployeeId);

        public IEnumerable<AnswerDetailsView> GetAnswersByEmployeeId(Guid employeeId,Guid currentEmployeeId);

        public void AddAnswer(Answer answer);

        public void VoteAnswer(EmployeeAnswerActivity answerActivity);

        public void BestSolution(Guid answerId);
    }
}

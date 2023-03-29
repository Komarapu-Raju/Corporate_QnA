using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Services.Interfaces;

namespace CorporateQnA.Services.Implementations
{
    public class AnswerService : IAnswerService
    {
        public void AddAnswer(Answer answer)
        {
            throw new NotImplementedException();
        }

        public void BestSolution(BestSolution bestSolution)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(int QuestionId)
        {
            throw new NotImplementedException();
        }

        public void VoteAnswer(EmployeeAnswerActivity newActivity)
        {
            throw new NotImplementedException();
        }
    }
}

using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.EmployeeActivities;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        public void AddAnswer(Answer answer);

        public IEnumerable<AnswerListItem> GetAnswersByQuestionId(int QuestionId);

        public void VoteAnswer(EmployeeAnswerActivity newActivity);

        public void BestSolution(BestSolution bestSolution);
    }
}

using CorporateQnA.Data.Models.Answer;
using CorporateQnA.Core.Models.EmployeeActivities;
using CorporateQnA.Data.Models.Answer.Views;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        public long AddAnswer(Answer answer);

        public IEnumerable<AnswerDetailsView> GetAnswersByQuestionId(int QuestionId);

        public void VoteAnswer(EmployeeAnswerActivity newActivity);

        public void BestSolution(Core.Models.Answers.BestSolution bestSolution);
    }
}

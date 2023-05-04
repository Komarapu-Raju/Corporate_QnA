using CorporateQnA.Core.Models.Answers;
using CorporateQnA.Core.Models.Answers.ViewModels;
using CorporateQnA.Core.Models.Enum;

namespace CorporateQnA.Services.Interfaces
{
    public interface IAnswerService
    {
        IEnumerable<AnswerListItem> GetAnswersByQuestionId(Guid questionId);

        void AddAnswer(Answer answer);

        void VoteAnswer(Guid answerId, Vote voteStatus);

        void UpdateBestSolution(Guid answerId);
    }
}
